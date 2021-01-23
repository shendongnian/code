    string json = @"[
        {
            ""Name"":""Mike"",
            ""Gender"":""male""
        },
        {
            ""Name"":""Lucy"",
            ""Gender"":""Female ""
        },
        {
            ""Name"":""Jack"",
            ""Gender"":""Male""
        }
    ]";
    MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ObjType[]));
    ObjType[] response = (ObjType[])jsonSerializer.ReadObject(stream);
-
    [DataContract]
    public class ObjType
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Gender;
    }
