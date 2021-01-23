        var serializer = new DataContractJsonSerializer(TheList.GetType());
        using (var stream = new MemoryStream())
        {
            serializer.WriteObject(stream, TheList);
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    Note, that this option requires definition of a data contract for your class:
        [DataContract]
        public class MyObjectInJson
        {
           [DataMember]
           public long ObjectID {get;set;}
           [DataMember]
           public string ObjectInJson {get;set;}
        }
