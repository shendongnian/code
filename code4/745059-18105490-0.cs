    public class FileData
    {
        public string Original { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        
        public int Weight { get { return GetWeight(Type); } }
        
        private static int GetWeight(string option)
        {
            switch(option)
            {
                case "pdf":
                    return 0;
                case "doc":
                    return 1;
                case "txt":
                    return 2;
                default:
                    return 3;
            }
        }
    }
