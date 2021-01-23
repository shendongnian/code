    public class Content
    {
        public int Key { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public static string getType(string id)
        {
            switch (id.Substring(2, 2))
            {
                case "00": return ("14");
                case "1F": return ("11");
                case "04": return ("10");
                case "05": return ("09");
                default: return ("99");
            }
        }
    }
