     public partial class SignalGraph : Window
        {
            private System.Threading.Timer timer;
            private Random random = new Random();
    
            public SignalGraph()
            {
                InitializeComponent();
    
                timer = new System.Threading.Timer(x => DrawRandomLine(), null, 0, 100);
            }
    
            private void DrawRandomLine()
            {
                Dispatcher.BeginInvoke((Action) (() => drawPoly(random.Next(0,100))), null);
            }
    
            static double xOld = 32;
            static double yOld = 580;
            static double t = 32;
            Path path;
            static GeometryGroup lineGroupDrw1 = new GeometryGroup();
    
            public void drawPoly(double value)
            {
                //increase point position
                t = t+5;
    
    
                //generate 2 point for the connection
                var pOne = new Point(xOld, yOld);
                var pTwo = new Point(t, value);
    
                //connect old point with new
                var lineGroup = new GeometryGroup();
                
                var connectorGeometry = new LineGeometry {StartPoint = pOne, EndPoint = pTwo};
                
                lineGroup.Children.Add(connectorGeometry);
                path = new Path
                           {
                               Data = lineGroup, 
                               StrokeThickness = 1,
                               Stroke = Brushes.Red,
                               Fill = Brushes.Red
                           };
    
                //fill the static linegroup with a new point
                lineGroupDrw1.Children.Add(connectorGeometry);
    
                //if (coordinateSystem.ActualWidth > t)
                //{
                    // draw graph
                    coordinateSystem.Children.Add(path);
                //}
                //else 
                //{
                //    //To do : update drawing
                //    updateDrawingEnd();
                //}
    
                //refresh values
                xOld = t;
                yOld = value;
    
            }
        }
