    public class Rootobject
    {
        public Responseheader responseHeader { get; set; }
        public Response       response       { get; set; }
    }
    public class Responseheader
    {
        public int    status  { get; set; }
        public int    QTime   { get; set; }
        public Params _params { get; set; }
    }
    public class Params
    {
        public string q  { get; set; }
        public string wt { get; set; }
        public string fq { get; set; }
    }
    public class Response
    {
        public int   numFound { get; set; }
        public int   start    { get; set; }
        public Doc[] docs     { get; set; }
    }
    public class Doc
    {
        public string   streetAddress  { get; set; }
        public float    estimate       { get; set; }
        public string   city           { get; set; }
        // etc ...
    }
