    public static class ExtensionMethod
    {  
        public static T DeepClone<T>(this T element)
        { 
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, element);
            m.Position = 0;
            return (T)b.Deserialize(m);
        }
    }
