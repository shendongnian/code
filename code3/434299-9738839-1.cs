    class Program
    {
        static void Main(string[] args)
        {
            var obj = "bugaga!";
            System.Runtime.Serialization.DataContractSerializer ser = new System.Runtime.Serialization.DataContractSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            using (XmlWriter xdw = XmlWriter.Create(ms))
            {
                ser.WriteObject(xdw, obj);
            }
            Console.WriteLine(ms.Length);
        }
    }
