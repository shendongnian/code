        public List<Assembly> MyViewAssemblies { get; set; }
        protected override IDictionary<System.Type, System.Type> GetViewModelViewLookup()
        {
            var toReturn = new Dictionary<Type, Type>();
            foreach (var assembly in MyViewAssemblies)
            {
                var contributions = base.GetViewModelViewLookup(assembly, typeof (IMvxAndroidView));
                foreach (var kvp in contributions)
                {
                    toReturn[kvp.Key] = kvp.Value; 
                }
            }
            return toReturn;
        }
