    public static class Extensions
    {
        public static bool HasKeyLike<T>(this Dictionary<string, T> collection, string value)
        {
            var keysLikeCount = collection.Keys.Count(x => x.ToLower().Contains(value.ToLower()));
            return keysLikeCount > 0;
        }
	
        public static List<string> GetKeysLike<T>(this Dictionary<string, T> collection, string value)
        {
            return collection.Keys.Select(x => x.ToLower().Contains(value.ToLower())).ToList();
        }
    }
