    var serializer = new DataContractJsonSerializer(typeof(List<Result>));
    var result = (List<Result>)serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json)));
    public class Result
    {
        public string ew;
        public List<string> hws;
    }
