    public class Graphics
    {
        public ObservableCollection<UIElement> UIElements { get; set; }
        public Graphics()
        {
            this.UIElements = new ObservableCollection<UIElement>();
            this.GenerateLines();
        }
        private void GenerateLines()
        {
            for (int i = 0; i < 200; i+=20)
            {
                Line line = new Line();
                // Line attributes
                line.Stroke = new SolidColorBrush(Colors.Purple);
                line.StrokeThickness = 15;
                Point point1 = new Point();
                point1.X = i;
                point1.Y = i;
                Point point2 = new Point();
                point2.X = i;
                point2.Y = i + 30;
                line.X1 = point1.X;
                line.Y1 = point1.Y;
                line.X2 = point2.X;
                line.Y2 = point2.Y;
                // Line attributes
                UIElements.Add(line);
            }
        }
    }
