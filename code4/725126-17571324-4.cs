    // This can (and should) implement INotifyPropertyChanged
    public class OfficeViewModel
    {
        public string EmployeeName { get; private set; }
        
        public ReadOnlyObservableCollection<Point> Points { get; private set; }
        ...
    }
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
