    public class SearchResult
        {
            public string Description { get; set; }
            public static List<SearchResult> GetResult()
            {
                var list = new List<SearchResult>()
                {
                    new SearchResult(){Description = "JCB Excavator - ECU P/N: 728/35700"},
                    new SearchResult(){Description = "Geo Prism 1995 Geo cart Geo001 -Geo ABS #16213899"},
                    new SearchResult(){Description = "Geo Prism 1995 - Geo ABS #16213899"},
                    new SearchResult(){Description = "Geo Prism 1995 - ABS #16213899"},
                    new SearchResult(){Description = "Wie man BBA reman erreicht"},
                    new SearchResult(){Description = "this JCB test JCB"},
                    new SearchResult(){Description = "Ersatz Airbags, Gurtstrammer und Auto Körper  Teile"}
                };
                return list;
            }
        }
