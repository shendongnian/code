    public class StackOverflow_15829446
    {
        private class ResourceConverterGen2 : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                SystemCertificate systemCertificate = (SystemCertificate)value;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("SystemID", systemCertificate.SystemId);
                dic.Add("Certificate", Convert.ToBase64String(systemCertificate.Certificate));
                serializer.Serialize(writer, dic);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var dic = serializer.Deserialize<Dictionary<string, string>>(reader);
                SystemCertificate systemCertificate = new SystemCertificate();
                systemCertificate.SystemId = dic["SystemID"];
                systemCertificate.Certificate = Convert.FromBase64String(dic["Certificate"]);
                return systemCertificate;
            }
            public override bool CanConvert(Type objectType)
            {
                return typeof(SystemCertificate) == objectType;
            }
        }
        public class SystemCertificate
        {
            public byte[] Certificate;
            public string SystemId;
        }
        public static void Test()
        {
            SystemCertificate cert = new SystemCertificate
            {
                SystemId = "123",
                Certificate = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };
            JsonSerializer js = new JsonSerializer();
            js.Converters.Add(new ResourceConverterGen2());
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            js.Serialize(sw, cert);
            Console.WriteLine(sb.ToString());
            StringReader sr = new StringReader(sb.ToString());
            SystemCertificate cert2 = (SystemCertificate)js.Deserialize(sr, typeof(SystemCertificate));
            Console.WriteLine("Id={0},Cert={1}", cert2.SystemId, string.Join(",", cert2.Certificate.Select(b => string.Format("{0:X2}", (int)b))));
        }
    }
