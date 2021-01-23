    public class OutputJsonResolver : DefaultContractResolver
    {
        #region Static Members
        private static readonly object syncTargets = new object();
        private static readonly Dictionary<Type, IList<JsonProperty>> Targets = new Dictionary<Type, IList<JsonProperty>>();
        private static readonly Assembly CommonAssembly = typeof(ICommon).Assembly;
        #endregion
        #region Override Members
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            if (type.Assembly != OutputJsonResolver.CommonAssembly)
                return base.CreateProperties(type, memberSerialization);
            IList<JsonProperty> properties;
            if (OutputJsonResolver.Targets.TryGetValue(type, out properties) == false)
            {
                lock (OutputJsonResolver.syncTargets)
                {
                    if (OutputJsonResolver.Targets.ContainsKey(type) == false)
                    {
                        properties = this.CreateCustomProperties(type, memberSerialization);
                        OutputJsonResolver.Targets[type] = properties;
                    }
                }
            }
            return properties;
        }
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToCase(Casing.Camel);
        }
        #endregion
        #region Assistants
        private IList<JsonProperty> CreateCustomProperties(Type type, MemberSerialization memberSerialization)
        {
            // Hierarchy
            IReadOnlyList<Type> types = this.GetTypes(type);
            // Head
            Type head = types.OrderByDescending(item => item.GetInterfaces().Length).FirstOrDefault();
            // Sources
            IList<JsonProperty> sources = base.CreateProperties(head, memberSerialization);
            // Targets
            IList<JsonProperty> targets = new List<JsonProperty>(sources.Count);
            // Repository
            IReadOnlyDistribution<Type, JsonProperty> repository = sources.ToDistribution(item => item.DeclaringType);
            foreach (Type current in types.Reverse())
            {
                IReadOnlyPage<JsonProperty> page;
                if (repository.TryGetValue(current, out page) == true)
                    targets.AddRange(page);
            }
            return targets;
        }
        private IReadOnlyList<Type> GetTypes(Type type)
        {
            List<Type> types = new List<Type>();
            if (type.IsInterface == true)
                types.Add(type);
            types.AddRange(type.GetInterfaces());
            return types;
        }
        #endregion
    }
