    public class LangPackDescriptor : ILangPackDescriptor { 
        public static string LangPackName = "American English";
        public string string CultureString = "en-US";
        ...
    }
    public class LangPackInit { 
        public void Init() {
            StringLib.MainFormTitle = "My Application Name"
            ...
        }
    }
