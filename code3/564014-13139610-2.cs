    [DataContract]
    public class BookCourse
    {
        [DataMember]
        public string coursesection { get; set; }
        [DataMember]
        public string netlogon { get; set; }
        [DataMember]
        public string label { get; set; }
    }
    [DataContract]
    public class BookCourceCollection
    {
        [DataMember]
        public List<BookCourse> Collection;
        public static BookCourceCollection ReturnCollection(string jsonString)
        {
            MemoryStream ms;
            BookCourceCollection collection;
            using (ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BookCourceCollection));
                collection = ser.ReadObject(ms) as BookCourceCollection;
            }
            return collection;
        }
    }
