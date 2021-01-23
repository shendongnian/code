    public class Point : INotifyPropertyChanged
    {
      public float X { get; set; }
      public float Y { get; set; }
    
      PropertyChangedEventHandler onPointsPropertyChanged;
    
      public Point()
      {
        onPointsPropertyChanged = (_, e) =>
        {
          X = 5;
          Y = 5;
        };
      }
    }
