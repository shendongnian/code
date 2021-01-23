    public interface IVocabulary
    {
        string Hello { get; }
    }
    public class EnglishVocabulary : IVocabulary
    {
        public string Hello
        {
            get { return "Hello"; }
        }
    }
    public class ItalianVocabulary : IVocabulary
    {
        public string Hello
        {
            get { return "Ciao"; }
        }
    }
    public class CurrentVocabulary
    {
        private static IVocabulary instance;
        private CurrentVocabulary()
        {
        }
        public static IVocabulary Instance
        {
            get
            {
                return instance;
            }
        }
        public static void SetVocabulary(string language)
        {
            switch (language.ToLower())
            {
                case "english":
                    instance = new EnglishVocabulary();
                    break;
                case "italian":
                    instance = new ItalianVocabulary();
                    break;
                default:
                    throw new ArgumentException("Language " + language + " not available.");
                    break;
            }
        }
    }
