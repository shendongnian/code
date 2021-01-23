     public class URL 
        { 
            public string Url { get; set; } 
            public string Title { get; set; } 
            public string Browser { get; set; } 
            public URL(string url, string title, string browser) 
            { 
                this.Url = url; 
                this.Title = title; 
                this.Browser = browser; 
            } 
        } 
