    using System.IO;
    
        [Serializable]
        class salesman
        {
            public string name, address, email;
            public int sales;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<salesman> salesmanList = new List<salesman>();
                string dir = @"c:\temp";
                string serializationFile = Path.Combine(dir, "salesmen.bin");
    
                //serialize
                using (Stream stream = File.Open(serializationFile, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    
                    bformatter.Serialize(stream, salesmanList);
                }
    
                //deserialize
                using (Stream stream = File.Open(serializationFile, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    
                    List<salesman>  salesman = (List<salesman>)bformatter.Deserialize(stream);
                }
            }
        }
