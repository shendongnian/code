    [DataContract]
    public class MyType
    {
        [DataMember(EmitDefaultValue = false)]
        public string Prop1 { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Prop2 { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Prop3 { get; set; }
    }
    public class Test
    {
        public static void Main()
        {
            var dcjs = new DataContractJsonSerializer(typeof(MyType));
            var ms = new MemoryStream();
            var data = new MyType { Prop2 = "Hello" };
            dcjs.WriteObject(ms, data);
            // This will write {"Prop2":"Hello"}
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
