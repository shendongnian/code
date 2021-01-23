        public static class QueryHelper
    {
        static object Get_FieldValue(object obj, string name, bool isBase)
        {
            if (isBase)
            {
                var _internalContext2 = obj.GetType().BaseType.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
                return _internalContext2.GetValue(obj);
            }
            var _internalContext = obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            return _internalContext.GetValue(obj);
        }
        static FieldInfo Get_Field(object obj, string name, bool isBase)
        {
            if (isBase)
            {
                var _internalContext2 = obj.GetType().BaseType.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
                return _internalContext2;
            }
            var _internalContext = obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            return _internalContext;
        }
        static object Get_PropertyValue(object obj, string name, bool isBase)
        {
            if (isBase)
            {
                var _internalContext2 = obj.GetType().BaseType.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                return _internalContext2.GetValue(obj);
            }
            var _internalContext = obj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return _internalContext.GetValue(obj);
        }
        static PropertyInfo Get_Property(object obj, string name, bool isBase)
        {
            if (isBase)
            {
                var _internalContext2 = obj.GetType().BaseType.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                return _internalContext2;
            }
            var _internalContext = obj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return _internalContext;
        }
        public static void SetInternalContextOfQuery(object old, object newobj)
        {
            var _internalQuery = Get_Field(old, "_internalQuery", false);
            var value = _internalQuery.GetValue(old);
            var _internalContext = Get_Field(value, "_internalContext", false);
            var _newInternalContext = Get_Property(newobj, "InternalContext", false);
            var _internalContextValue = _newInternalContext.GetValue(newobj);
            _internalContext.SetValue(value, _internalContextValue);
            var _ObjectContext = Get_Property(_internalContextValue, "ObjectContext", false);
            var _ObjectContextValue = _ObjectContext.GetValue(_internalContextValue);
            var _objectQuery = Get_Field(value, "_objectQuery", false);
            var _objectQueryValue = _objectQuery.GetValue(value);
            var _providerProperty = Get_Property(_objectQueryValue, "ObjectQueryProvider", false);
            var justV = _providerProperty.GetValue(_objectQueryValue);
            var _provider = Get_Field(_objectQueryValue, "_provider", true);
            var _providerValue = _provider.GetValue(_objectQueryValue);
            var _provider_context = Get_Field(_providerValue, "_context", false);
            var context = Get_Property(_objectQueryValue, "Context", false);
            _provider_context.SetValue(_providerValue, _ObjectContextValue);
            var _query = Get_Property(_objectQueryValue, "QueryState", false);
            var _queryValue = _query.GetValue(_objectQueryValue);
            var _query_context = Get_Field(_queryValue, "_context", true);
            //context.SetValue(_objectQueryValue, _ObjectContextValue);
            _query_context.SetValue(_queryValue, _ObjectContextValue);
            var expersionProperty = Get_Property(value, "Expression", false);
            var expersion = (System.Linq.Expressions.MethodCallExpression)Get_PropertyValue(value, "Expression", false);
            var result = System.Linq.Expressions.Expression.Lambda(expersion).Compile();
            var target = (System.Runtime.CompilerServices.Closure)Get_PropertyValue(result, "Target", false);
            var exProvider = Get_FieldValue(target.Constants[0], "_provider", true);
            var exProviderField = Get_Field(exProvider, "_context", false);
            exProviderField.SetValue(exProvider, _ObjectContextValue);
            var ex_queryProvider = Get_PropertyValue(target.Constants[0], "QueryState", true);
            var ex_queryProviderField = Get_Field(ex_queryProvider, "_context", true);
            //System.Linq.Expressions.Expression.Call()
            ex_queryProviderField.SetValue(ex_queryProvider, _ObjectContextValue);
            var ObjectQuery = Get_PropertyValue(value, "ObjectQuery", false);
            var QueryState = Get_PropertyValue(ObjectQuery, "QueryState", false);
            var _expression = Get_Field(QueryState, "_expression", false);
            var a = expersion.Arguments.ToArray();
            List<System.Linq.Expressions.ConstantExpression> items = new List<System.Linq.Expressions.ConstantExpression>();
            foreach (var item in ((System.Runtime.CompilerServices.Closure)result.Target).Constants)
            {
                items.Add(System.Linq.Expressions.Expression.Constant(item));
            }
            System.Linq.Expressions.MethodCallExpression methodCall =
                System.Linq.Expressions.Expression.Call(expersion.Method, items);
            //var exV=  System.Linq.Expressions.Expression.Lambda(methodCall);
            _expression.SetValue(QueryState, methodCall);
        }
    }
