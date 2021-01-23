    public class RectangleHighlightDataObject
    {
        public Rect Bounds { get; set; }
        public double StrokeThickness { get; set; }
        public Brush Fill { get; set; }
        public String ToolTip { get; set; }
    }
    public class VisualizationWindow
    {
        public VisualizationWindow() 
        {
             DataCollection.Add(new RectangleHighlightDataObject()
             {
                 Bounds = new Rect(-1,-1.5,.5,2),
                 StrokeThickness = 3,
                 Fill = Brushes.Blue,
                 ToolTip = "Blue!"
             });
             DataCollection.Add(new RectangleHighlightDataObject()
             {
                 Bounds = new Rect(1,1.5,2,.5),
                 StrokeThickness = 1,
                 Fill = Brushes.Red,
                 ToolTip = "Red!"
             });
        }
        public ObservableCollection<RectangleHighlightDataObject> DataCollection = 
                 new ObservableCollection<RectangleHighlightDataObject>();
    }
