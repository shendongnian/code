    public class CurveViewModel : ViewModelBase
    {
        private Collection<PathSegment> _segments;
        private readonly ObservableCollection<Coordinate> _userInputCoordinates;
    
        public ObservableCollection<Coordinate> UserInputCoordinates
        {
            get { return _userInputCoordinates; }
        }
    
        public Collection<PathSegment> Segments
        {
            get { return _segments; }
            private set
            {
                _segments = value;
                OnPropertyChanged(() => Segments);
            }
        }
    
        public CurveViewModel()
        {
            _userInputCoordinates = new ObservableCollection<Coordinate>();
    
            // Subscribe to refresh the path on adding/deleting ne coordinates
            UserInputCoordinates.CollectionChanged += UserInputCoordinates_CollectionChanged;
        }
    
        private void UserInputCoordinates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var newItems = args.NewItems.OfType<INotifyPropertyChanged>();
                    foreach (var coordinate in newItems)
                    {
                        // Subscribe to property change of a particular coordinate to refresh the 
                        // curve when user changes the values of an already existing coordinate data set
                        coordinate.PropertyChanged += Coordinate_PropertyChanged;
                    }
                    break;
    
                case NotifyCollectionChangedAction.Remove:
                    var oldItems = args.OldItems.OfType<INotifyPropertyChanged>();
                    foreach (var coordinate in oldItems)
                    {
                        // Unsubscribe to avoid memory leaks
                        coordinate.PropertyChanged -= Coordinate_PropertyChanged;
                    }
                    break;
            }
    
            // This refreshes the path when a coordinate has been added/removed
            RefreshPath();
        }
    
        private void Coordinate_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RefreshPath();
        }
    
        private void RefreshPath()
        {
            var segments = new Collection<PathSegment>();
    
            foreach (var userInputCoordinate in UserInputCoordinates)
            {
                var segment = new QuadraticBezierSegment();
                // Set properties here
                segments.Add(segment);
            }
    
            Segments = segments;
        }
    
        public class Coordinate : ViewModelBase
        {
            private double _xStart;
            
            public double XStart
            {
                get { return _xStart; }
                set
                {
                    _xStart = value;
                    OnPropertyChanged("XStart");
                }
            }
    
            // Analogous properties for YStart, XEnd, YEnd, XControl, YControl
        }
    }
