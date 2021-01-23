    public class Genres
    {
        public Metadata metadata;
        public Result[] results;
    }
    public class Metadata
    {
        public int page;
        public int perPage;
        public int count;
    }
    public class Result
    {
        public int id;
        public string name;
        public string slug;
        //public subgenre[] subgenres;
    }
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Genres));
    Genres data = serializer.ReadObject(e.Result) as Genres;
