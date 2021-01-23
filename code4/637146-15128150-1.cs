    public class ColorViewModel : INotifyPropertyChanged
    {
        private Color color;
        public Color Color
        {
            get { return color; }
            set
            {
                if (value != color)
                {
                    color = value;
                    NotifyPropertyChanged("Color");
                }
            }
        }
        // INotifyPropertyChanged implementation goes here
    }
