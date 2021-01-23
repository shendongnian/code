    public class InstanceCreator {
    
        static public readonly Func<FieldInfo, PropertyInfo, bool> NamingConvention;
    
        static InstanceCreator() {
            NamingConvention = (f, p) => {
                var startsWithUnderscope = f.Name.StartsWith("_");
                var hasSameName = p.Name.Equals(f.Name.Remove(0, 1), StringComparison.OrdinalIgnoreCase);
                var hasSameType = f.FieldType == p.PropertyType;
                return startsWithUnderscope && hasSameName && hasSameType &&
                       f.IsInitOnly && !p.CanWrite;
            };
        }
    
        private readonly Type _type;
        private readonly Func<IDictionary<string, object>, dynamic> _creator;
    
        public InstanceCreator(Type type) {
            _type = type;
            var ctor = GetCtor(type);
            var propertyToFieldMappers = MakeMappers(type);
            _creator = MakeCreator(type, ctor, propertyToFieldMappers);
        }
    
        private Expression GetCtor(Type type) {
            if (type == typeof(string)) // ctor for string
                return Expression.Lambda<Func<dynamic>>(
                    Expression.Constant(string.Empty));
            if (type.IsValueType || // type has a parameterless ctor
                type.GetConstructor(Type.EmptyTypes) != null)
                return Expression.Lambda<Func<dynamic>>(Expression.New(type));
            var info = typeof(FormatterServices).GetMethod("GetUninitializedObject");
            return Expression.Call(info, Expression.Constant(type));
        }
    
        private IEnumerable<PropertyToFieldMapper> MakeMappers(Type type) {
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var list = from field in fields
                        let property = properties.FirstOrDefault(prop => NamingConvention(field, prop))
                        where property != null
                        select new PropertyToFieldMapper(field, property);
            return list;
        }
    
        private Func<IDictionary<string, object>, dynamic> MakeCreator(
            Type type, Expression ctor,
            IEnumerable<PropertyToFieldMapper> maps) {
            var list = new List<Expression>();
            var vList = new List<ParameterExpression>();
            // creating new target
            var targetVariable = Expression.Variable(type, "targetVariable");
            vList.Add(targetVariable);
            list.Add(Expression.Assign(targetVariable, Expression.Convert(ctor, type)));
            // accessing source
            var sourceType = typeof(IDictionary<string, object>);
            var sourceParameter = Expression.Parameter(sourceType, "sourceParameter");
            // calling source ContainsKey(string) method
            var containsKeyMethodInfo = sourceType.GetMethod("ContainsKey", new[] { typeof(string) });
            var accessSourceIndexerProp = sourceType.GetProperty("Item");
            var accessSourceIndexerInfo = accessSourceIndexerProp.GetGetMethod();
            // itrate over writers and add their Call to block
            var containsKeyMethodArgument = Expression.Variable(typeof(string), "containsKeyMethodArgument");
            vList.Add(containsKeyMethodArgument);
            foreach (var map in maps) {
                list.Add(Expression.Assign(containsKeyMethodArgument, Expression.Constant(map.Property.Name)));
                var containsKeyMethodCall = Expression.Call(sourceParameter, containsKeyMethodInfo,
                                                            new Expression[] { containsKeyMethodArgument });
                // creating writer
                var sourceValue = Expression.Call(sourceParameter, accessSourceIndexerInfo,
                                                  new Expression[] { containsKeyMethodArgument });
                var setterInfo = map.Field.GetType().GetMethod("SetValue", new[] { typeof(object), typeof(object) });
                var setterCall = Expression.Call(Expression.Constant(map.Field), setterInfo,
                    new Expression[] {
                                         Expression.Convert(targetVariable,typeof(object)),
                                         Expression.Convert(sourceValue,typeof(object))
                                     });
                list.Add(Expression.IfThen(containsKeyMethodCall, setterCall));
            }
            list.Add(targetVariable);
            var block = Expression.Block(vList, list);
            var lambda = Expression.Lambda<Func<IDictionary<string, object>, dynamic>>(
                block, new[] { sourceParameter }
                );
            return lambda.Compile();
        }
    
        public dynamic Create(IDictionary<string, object> data) {
            return _creator.Invoke(data);
        }
    
        private class PropertyToFieldMapper {
    
            private readonly FieldInfo _field;
            private readonly PropertyInfo _property;
    
            public PropertyToFieldMapper(FieldInfo field, PropertyInfo property) {
                _field = field;
                _property = property;
            }
    
            public FieldInfo Field {
                get { return _field; }
            }
    
            public PropertyInfo Property {
                get { return _property; }
            }
        }
    }
