    public class StackOverflow_15752476
    {
        const string jsonString = @" 
            {
                ""RequestId"":514106,
                ""Warning"":[],
                ""CustomerData"": {
                    ""Email"":""abc@abc.com"",
                    ""FullName"":""OrTguOfE"",
                    ""OrderData"":[{
                        ""OrderId"":""123"",
                        ""SourceId"":""0"",
                        ""SourceData"": [{
                            ""SourceDescription"":""This is sourcedesc"",
                            ""ProductName"":""xyzabc""
                        }]
                    }]
                }
            }";
        public static void Test()
        {
            RecordInfo records = Deserialize<RecordInfo>(jsonString);
            Console.WriteLine(records.CustomerData.OrderData.Length);
            Console.WriteLine(records.CustomerData.OrderData[0].OrderId);
            Console.WriteLine(records.CustomerData.OrderData[0].SourceId);
            Console.WriteLine(records.CustomerData.OrderData[0].SourceData[0].ProductName);
        }
        private static T Deserialize<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }
        [DataContract]
        public class RecordInfo
        {
            [DataMember(Name = "RequestId")]
            public string RequestId { get; set; }
            [DataMember(Name = "Warning")]
            public string Warning { get; set; }
            [DataMember(Name = "CustomerData")]
            public CustomerData CustomerData { get; set; }
        }
        [DataContract]
        public class CustomerData
        {
            [DataMember(Name = "Email")]
            public string RequestId { get; set; }
            [DataMember(Name = "FullName")]
            public string FullName { get; set; }
            [DataMember(Name = "OrderData")]
            public OrderData[] OrderData { get; set; }
        }
        [DataContract]
        public class OrderData
        {
            [DataMember(Name = "OrderId")]
            public string OrderId { get; set; }
            [DataMember(Name = "SourceId")]
            public string SourceId { get; set; }
            [DataMember(Name = "SourceData")]
            public SourceData[] SourceData { get; set; }
        }
        [DataContract]
        public class SourceData
        {
            [DataMember(Name = "SourceDescription")]
            public string SourceDescription { get; set; }
            [DataMember(Name = "ProductName")]
            public string ProductName { get; set; }
        }
    }
