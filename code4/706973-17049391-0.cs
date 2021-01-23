        public static uint[] Pixels(Texture2D texture)
        {
            uint[] data = new uint[texture.Width * texture.Height];
            texture.GetData(data);
            return data;
        }
        public static Dictionary<Texture2D, uint[]> PixelMaps(IEnumerable<Texture2D> textures)
        {
            return textures.ToDictionary(t => t, Pixels);
        }
