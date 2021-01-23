        public static void loadTransformers()
        {
            var baseType = typeof(BaseClass).GetTypeInfo();
            var attributes = baseType.Assembly.DefinedTypes.Where(
                z => baseType.IsAssignableFrom(z))
                .SelectMany(t => t.GetCustomAttributes<PostTransformerAttribute>(false));
        }
