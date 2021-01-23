        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Point newPoint;
            Rectangle rectangle;
            newPoint = GetRandomPoint();
            rectangle = new Rectangle {Width = 4, Height = 4, Fill = Brushes.Red};
            rectangle.MouseMove += new MouseEventHandler(rectangle_MouseMove);
            m_Points.Add(newPoint);
            PointCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle,newPoint.Y);
            Canvas.SetLeft(rectangle,newPoint.X);
        }
        void rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;
            Point newPoint;
            newPoint = GetRandomPoint();
            Canvas.SetTop(rectangle, newPoint.Y);
            Canvas.SetLeft(rectangle, newPoint.X);
        }
