    public class Settings : INotifyPropertyChanged  
    {
        public Settings(string name, string image, bool onOff)
        {
            Name = name;
            Image = new BitmapImage (new Uri(image, UriKind.Absolute));
            OnOff = onOff;
        }
    
        public string Name { get; set; }
        public ImageSource Image { get; set; }
    
        private bool m_onOff;
        public bool OnOff 
            {
            get { return m_onOff; }
            set { 
                m_onOff = value;
                if (PropertyChanged != null)
                    {
                    PropertyChanged (this, new PropertyChangedEventArgs ("OnOff"));
                    }
                } 
            }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
