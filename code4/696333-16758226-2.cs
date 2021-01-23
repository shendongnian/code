    var op = JsonConvert.DeserializeObject<AllResults>(input);
    foreach (var item in op.results)
    {
        Console.WriteLine(item.original_title);
    }
    public class Result
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string __invalid_name__release_date { get; set; }
        public string poster_path { get; set; }
        public double popularity { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public int __invalid_name__vote_count { get; set; }
        public string release_date { get; set; }
        public int? vote_count { get; set; }
    }
    public class AllResults
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
