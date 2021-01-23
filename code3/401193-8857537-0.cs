    public static class StreamSerializer
    {
        public static void Serialize<T>(IList<T> list, string filename)
        {
            using (Stream stream = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                // seralize each object separately
                foreach (var item in list)
                    bin.Serialize(stream, item);
            }
        }
        public static IEnumerable<T> Deserialize<T>(string filename)
        {
            using (Stream stream = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                // deserialize each object separately, and 
                // return them one at a time
                while (stream.Position < stream.Length)
                    yield return (T)bin.Deserialize(stream);
            }
        }
    }
