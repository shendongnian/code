    public class LangPackDescriptor : ILangPackDescriptor { 
        public readonly string LangPackName = "American English";
        public readonly string CultureString = "en-US";
        ...
    }
    public class EnUsLangPackInit : ILangPackInit { 
        public void Init() {
            StringLib.MainFormTitle = "My Application Name"
            ...
        }
    }
