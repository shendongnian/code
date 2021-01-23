    public sealed class UILanguage
    {
        public string EnglishName { set; get; }
        public string Culture { set; get; }
        public string SpecCulture { set; get; }
        public override string ToString()
        {
            return EnglishName;
        }
    } 
