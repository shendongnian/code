    class Texture2DRepository
    {
        static Dictionary<String, Texture2D> _textures = new Dictionary<String, Texture2D>();
        public static void Add(String key, Texture2D texture)
        {
            //maybe add logic to replace entries with same key
            Dictionary.Add(key, texture);
        }
        public static Texture2D Get(String key)
        {
            return Dictionary[key];
        }
    }
