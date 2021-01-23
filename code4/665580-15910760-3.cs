    public abstract class Section:PropertyChangedBase
        {
            public string Name { get; set; }
    
            private bool _isEnabled = true;
            public bool IsEnabled
            {
                get { return _isEnabled; }
                set
                {
                    _isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
    
            private bool _isVisible = true;
            public bool IsVisible
            {
                get { return _isVisible; }
                set
                {
                    _isVisible = value;
                    OnPropertyChanged("IsVisible");
                }
            }
    
            //Optionally
            //public string ImageSource {get;set;}
            //ImageSource = "/Resources/MySection.png";
        }
    
        public class FileSection: Section
        {
            ///... Custom logic specific to this Section
        }
    
        public class NetworkDesignSection:Section
        {
            ///... Custom logic specific to this Section
        }
    
        public class SelectAnalysisSection: Section
        {
            ///... Custom logic specific to File Section
        }
    
        //...etc etc etc
