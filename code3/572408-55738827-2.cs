        public Type GetCityType(string cityId, MyConfigSection config)
        {
            var typeName = config.Cities
                .Where(x => x.Id == cityId)
                .Select(x => x.Type);
            return Type.GetType(typeName);
        }
