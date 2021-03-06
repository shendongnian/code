        public static IEnumerable<T> Get<T>(string query, Dictionary<string, object> dictionary)
        {
            IEnumerable<T> entities = connection.Query<T>(query, new DynamicParameters(dictionary));
            return entities;
        }
