    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICollection<Point> segmentPoints;
        public ICollection<Point> SegmentPoints
        {
            get { return segmentPoints; }
            set
            {
                segmentPoints = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SegmentPoints"));
                }
            }
        }
    }
