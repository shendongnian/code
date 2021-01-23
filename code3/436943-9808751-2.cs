        public class StringDictionary : IStringDictionary
        {
            private Dictionary<string, string> _dictionary;
    
            public StringDictionary(string languageName = "default")
            {
    
                DictionaryLanguage = languageName;
    
            }
    
            public string Start
            {
                get { return _dictionary["start"]; }
                //your predefined key here, (should probably fallback / return null, or something)
            }
    
    
    
            private string _dictionaryLanguage;
    
            public string DictionaryLanguage
            {
                get { return _dictionaryLanguage; }
                set
                {
                    if (_dictionaryLanguage == value) return;
                    _dictionaryLanguage = value;
                    _dictionary = LoadFromDisk("strings." + value); //create this method
                }
            }
    
    
    
        }
