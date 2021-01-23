        public class Article
        {
            public string tileImg { get; set; }
            public string tileTit { get; set; }
            public string tileArt { get; set; }
        }
        
        public class OptionList
        {
            public string OptionNr { get; set; }
            public List<string> Options { get; set; }
        }
        public class ProductDetail
        {
            public string ProjectImg { get; set; }
            public string Category { get; set; }
            public string ProjectTitle { get; set; }
            public string ProjectDesc { get; set; }
            public List<string> GenSpecList { get; set; }
            public List<OptionList> OptionList { get; set; }
            public List<Article> Articles { get; set; }
        }
        
        public class RootObject
        {
            public List<ProductDetail> ProductDetail { get; set; }
        }
