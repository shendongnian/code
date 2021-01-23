    public class Genres
    {
        public metadata metadata;
        public result[] results;
    }
    public class metadata
    {
        public int page;
        public int perPage;
        public int count;
    }
    public class result
    {
        public int id;
        public string name;
        public string slug;
        //public subgenre[] subgenres;
    }
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Genres));
    Genres data = serializer.ReadObject(e.Result) as Genres;
