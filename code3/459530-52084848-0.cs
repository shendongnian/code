                // Use Method to Serialize and D-Serialize Collection object from memory. 
                // This works on Collection Data Types.
                // This Method will Serialize collection of any type to a byte stream
               // Create a Seperate Class SerilizeDeserialize.cs and add these two methods
               
        public class SerilizeDeserialize
            {
                
                 // Serialize collection of any type to a byte stream
        
                public static byte[] Serialize<T>(T obj)
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        BinaryFormatter binSerializer = new BinaryFormatter();
                        binSerializer.Serialize(memStream, obj);
                        return memStream.ToArray();
                    }
                }
        
        // DSerialize collection of any type to a byte stream
        
                public static T Deserialize<T>(byte[] serializedObj)
                {
                    T obj = default(T);
                    using (MemoryStream memStream = new MemoryStream(serializedObj))
                    {
                        BinaryFormatter binSerializer = new BinaryFormatter();
                        obj = (T)binSerializer.Deserialize(memStream);
                    }
                    return obj;
                }
        
            }     
    
    // How To use these method in your Class
    
    ArrayList arrayListMem = new ArrayList() { "One", "Two", "Three", "Four", "Five", "Six", "Seven" };
                Console.WriteLine("Serializing to Memory : arrayListMem");
                byte[] stream = SerilizeDeserialize.Serialize(arrayListMem);
    
                ArrayList arrayListMemDes = new ArrayList();
    
                arrayListMemDes = SerilizeDeserialize.Deserialize<ArrayList>(stream);
    
                Console.WriteLine("DSerializing From Memory : arrayListMemDes");
                foreach (var item in arrayListMemDes)
                {
                    Console.WriteLine(item);
                }
