        public class Episode
        {
            public string EPISODE { get; set; }
            public string TITLE { get; set; }
            public string DIRECTOR { get; set; }
            public string WRITER { get; set; }
            public string AIRDATE { get; set; }
            public string SYPNOSIS { get; set; }
            public Uri IMAGE { get; set; }
        }
        public class public class RootObject
        {
            public List<Episode> SEASON1 { get; set; }
            public List<Episode> SEASON2 { get; set; }
            public List<Episode> SEASON3 { get; set; }
        }
