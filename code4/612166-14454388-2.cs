    public class TranslationText
        {
            private string _translation;
            private bool _isTranslated;
    
            public string Translation
            {
                get { return _translation; }
                set
                {
                    _translation = value;
                }
            }
    
            public bool IsTranslated
            {
                get { return _isTranslated; }
                set
                {
                    _isTranslated = value;
                }
            }
    
        }
