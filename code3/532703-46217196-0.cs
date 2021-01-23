        internal sealed class ProtobufSerializer
        {
            private readonly RuntimeTypeModel _model;
            private const BindingFlags Flags = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            private readonly Dictionary<Type, HashSet<Type>> _subTypes = new Dictionary<Type, HashSet<Type>>();
            private readonly ConcurrentDictionary<Type, bool> _builtTypes = new ConcurrentDictionary<Type, bool>();
            private static readonly Type[] ComplexPrimitives = new [] { typeof(object), typeof(ValueType), typeof(Enum), typeof(Array)};
            private readonly object _sync = new object();
            public ProtobufSerializer()
            {
                _model = TypeModel.Create();
            }
            public void Serialize(Stream s, object input)
            {
                EnsureType(input.GetType());
                _model.Serialize(s, input);
            }
            public T Deserialize<T>(Stream s)
            {
                EnsureType(typeof(T));
                return (T)_model.Deserialize(s, null, typeof(T));
            }
            public void EnsureType(Type type)
            {
                if (_builtTypes.ContainsKey(type))
                {
                    return;
                }
                lock (_sync)
                {
                    if (_builtTypes.ContainsKey(type))
                    {
                        return;
                    }
                    var all = GetGraph(type).ToArray();
                    foreach (var t in all)
                    {
                        InternalBuild(t);
                    }
                }
            }
            private void InternalBuild(Type type)
            {
                if (IsPrimitive(type))
                {
                    return;
                }
                FlatBuild(type);
                EnsureBaseClasses(type);
                EnsureGenerics(type);
                _builtTypes.TryAdd(type, false);
            }
            private bool IsPrimitive(Type type)
            {
                return type == null || type.IsPrimitive || _model.CanSerializeBasicType(type) || _builtTypes.ContainsKey(type) || ComplexPrimitives.Contains(type);
            }
            private static IEnumerable<Type> GetGraph(Type type)
            {
                return type.TraverseDistinct(GetConnections).Distinct().OrderBy(x=> x.FullName);
            }
            private static Type GetParent(Type type)
            {
                return type.BaseType;
            }
            private static IEnumerable<Type> GetChildren(Type type)
            {
                var knownTypes = type.GetCustomAttributes(typeof(KnownTypeAttribute)).Cast<KnownTypeAttribute>().Select(x => x.Type).ToArray();
                foreach (var t in knownTypes)
                {
                    yield return t;
                }
                var fields = GetFields(type);
                var props = GetProperties(type);
                foreach (var memberType in fields.Select(f => f.FieldType))
                {
                    yield return memberType;
                }
                foreach (var memberType in props.Select(f => f.PropertyType))
                {
                    yield return memberType;
                }
            }
            private static IEnumerable<Type> GetConnections(Type type)
            {
                var parent = GetParent(type);
                if (parent != null)
                {
                    yield return parent;
                }
                var children = GetChildren(type);
                if (children != null)
                {
                    foreach (var c in children)
                    {
                        yield return c;
                    }
                }
            }
            private void FlatBuild(Type type)
            {
                if(type.IsAbstract)
                    return;
                
                var meta = _model.Add(type, false);
                var fields = GetFields(type);
                var props = GetProperties(type);
                meta.Add(fields.Select(m => m.Name).ToArray());
                meta.Add(props.Select(m => m.Name).ToArray());
                meta.UseConstructor = false;
                foreach (var memberType in fields.Select(f => f.FieldType).Where(t => !t.IsPrimitive))
                {
                    InternalBuild(memberType);
                }
                foreach (var memberType in props.Select(f => f.PropertyType).Where(t => !t.IsPrimitive))
                {
                    InternalBuild(memberType);
                }
            }
            private static FieldInfo[] GetFields(Type type)
            {
                return type.GetFields(Flags).Where(x => x.IsDefined(typeof(DataMemberAttribute))).Where(x => !x.IsDefined(typeof(IgnoreDataMemberAttribute))).ToArray();
            }
            private static PropertyInfo[] GetProperties(Type type)
            {
                return type.GetProperties(Flags).Where(x => x.IsDefined(typeof(DataMemberAttribute))).Where(x=> !x.IsDefined(typeof(IgnoreDataMemberAttribute))).ToArray();
            }
            private void EnsureBaseClasses(Type type)
            {
                var baseType = type.BaseType;
                var inheritingType = type;
                while (!IsPrimitive(baseType))
                {
                    HashSet<Type> baseTypeEntry;
                    if (!_subTypes.TryGetValue(baseType, out baseTypeEntry))
                    {
                        baseTypeEntry = new HashSet<Type>();
                        _subTypes.Add(baseType, baseTypeEntry);
                    }
                    if (!baseTypeEntry.Contains(inheritingType))
                    {
                        InternalBuild(baseType);
                        _model[baseType].AddSubType(baseTypeEntry.Count + 500, inheritingType);
                        baseTypeEntry.Add(inheritingType);
                    }
                    inheritingType = baseType;
                    baseType = baseType.BaseType;
                }
            }
            private void EnsureGenerics(Type type)
            {
                if (type.IsGenericType || (type.BaseType != null && type.BaseType.IsGenericType))
                {
                    var generics = type.IsGenericType ? type.GetGenericArguments() : type.BaseType.GetGenericArguments();
                    foreach (var generic in generics)
                    {
                        InternalBuild(generic);
                    }
                }
            }
        }
