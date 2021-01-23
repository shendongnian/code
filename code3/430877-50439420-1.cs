    public static List<T> MapDynamicList<T>(IEnumerable<object> obj)
        {
            var config = new MapperConfiguration(c => c.CreateMissingTypeMaps = true);
            var mapper = config.CreateMapper();
            var newModel = obj.Select(mapper.Map<T>).ToList();
            return newModel;
        }
