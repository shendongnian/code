    using System.Runtime.Serialization.Formatters.Binary;
    
    class Program
    {
        const string file = @"C:\temp\file.dat";
    
        static void Main()
        {
            for (int i = 0; i < 3; ++i)
            {
                List<int> tl = new List<int>();
                tl.Add(5);
                tl.Add(4);
                
                AppendToDisk<int>(tl);
            }
            
            var list = ReadFromDisk<int>();
            
            foreach(var item in list)
            {
                Console.Write(item);
            }
        }
    
        private void AppendToDisk<T>(ICollection<T> collection)
        {
            var existing = ReadFromDisk<T>().ToList().Dump();
            
            foreach(var value in collection)
            {
                existing.Add(value);
            }
            
            PersistToDisk(existing);
        }
        
        private void PersistToDisk<T>(ICollection<T> value)
        {
            if(!File.Exists(file))
            {
                using(File.Create(file)) { };
            }
            
            var bFormatter = new BinaryFormatter();
            using(var stream = File.OpenWrite(file))
            {
                bFormatter.Serialize(stream, value);
            }
        }
        
        private ICollection<T> ReadFromDisk<T>()
        {   
            if(!File.Exists(file)) return Enumerable.Empty<T>().ToArray();
            
            var bFormatter = new BinaryFormatter();
            using(var stream = File.OpenRead(file))
            {
                return (ICollection<T>) bFormatter.Deserialize(stream);
            }
        }
    }
