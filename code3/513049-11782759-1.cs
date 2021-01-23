    public class Links<Link> : BaseArrayClass<Link> //use whatever base collection extension you actually need here
    {
        //...stuff...//
    }
    public class Link
    {
        [XmlAttribute("href")]
        public string Url { get; set; }
        [XmlAttribute("rel")]
        public string Relationship { get; set; }
    }
