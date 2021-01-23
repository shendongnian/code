     public class Graphics
    {
        public ObservableCollection<UIElement> UIElements { get; set; }
        int poisiton = 0;
        private Timer backgroundTimer;
        public Graphics()
        {
            this.UIElements = new ObservableCollection<UIElement>();
            this.backgroundTimer = new Timer(new TimerCallback((timer) => {
                Deployment.Current.Dispatcher.BeginInvoke(() => this.GenerateLine());
            }), null, 2000, 3000);
        }
        private void GenerateLine()
        {
            Line line = new Line();
            // Line attributes
            line.Stroke = new SolidColorBrush(Colors.Purple);
            line.StrokeThickness = 15;
            Point point1 = new Point();
            point1.X = this.poisiton;
            point1.Y = this.poisiton;
            Point point2 = new Point();
            point2.X = this.poisiton;
            point2.Y = this.poisiton + 30;
            line.X1 = point1.X;
            line.Y1 = point1.Y;
            line.X2 = point2.X;
            line.Y2 = point2.Y;
            // Line attributes
            this.poisiton += 10;
            UIElements.Add(line);
        }
    }
