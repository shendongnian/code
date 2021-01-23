    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
        }
        public Double RelativeWidth
        {
            get { return relativeWidth; }
            set
            {
                if (relativeWidth != value)
                {
                    relativeWidth = value;
                    OnPropertyChanged("RelativeWidth");
                }
            }
        }
        private Double relativeWidth;
    }
