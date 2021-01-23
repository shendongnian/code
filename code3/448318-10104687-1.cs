    public static class Program
    {
        static void Main()
        {
            var obj = FieldType.Default;
    
            using(var ms = new MemoryStream())
            {
                var ser = new DataContractSerializer(typeof (FieldType));
                ser.WriteObject(ms, obj);
                ms.Position = 0;
                var obj2 = ser.ReadObject(ms);
    
                bool pass = ReferenceEquals(obj, obj2); // true
            }
        }
    }
