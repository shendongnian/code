     public static readonly DependencyProperty SelectedShapeProperty =
           DependencyProperty.Register
           ("SelectedShape", typeof(Polygon), typeof(MainWindow));
        public Polygon Polygon 
        {
            set{SetValue(SelectedShapeProperty, value);}
            get{return (Polygon) GetValue(SelectedShapeProperty);}
        }
     private void canvas1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (rbDraw.IsChecked ?? false)
            {
                if (e.OriginalSource is Ellipse)
                {
                    canvas1.Children.Remove((Ellipse)e.OriginalSource);
                    canvas1.Children.Remove(polyline);
                    Polygon tmpPolygon = new Polygon();
                    tmpPolygon.StrokeThickness = 2;
                    tmpPolygon.Stroke = Brushes.Black;
                    tmpPolygon.Points = polylinePoints.Clone();
                    polylinePoints.Clear();
                    polygons.Add(tmpPolygon);
                    drawOnMove = false;
                    rbDraw.IsChecked = false;
                    tmpPolygon.Fill = Brushes.Gray;
                    canvas1.Children.Add(tmpPolygon);
                    rbSelect.IsChecked = true;
                }
                else
                {
                    polylinePoints.Add(e.GetPosition(canvas1));
                    polyline.Points = polylinePoints.Clone();
                    if (polyline.Points.Count == 1)
                    {
                        Ellipse el = new Ellipse();
                        el.Width = 10;
                        el.Height = 10;
                        el.Stroke = Brushes.Black;
                        el.StrokeThickness = 2;
                        el.Fill = new SolidColorBrush { Color = Colors.Yellow };
                        InkCanvas.SetLeft(el, polyline.Points[0].X - el.Width / 2);
                        InkCanvas.SetTop(el, polyline.Points[0].Y - el.Height / 2);
                        
                        el.Margin =
                            new Thickness(left: polyline.Points[0].X - el.Width / 2, top: polyline.Points[0].Y - el.Height / 2, right: 0, bottom: 0);
                        canvas1.Children.Add(el);
                    }
                    drawOnMove = true;
                }
            }
            else if (rbSelect.IsChecked ?? false)
            {
                if (e.OriginalSource is Polygon && Polygon == null)
                {
                    Shape s = (Shape)e.OriginalSource;
                    Polygon = (Polygon)s;
                    Polygon.Opacity = 0.75;
                }
                else if (e.OriginalSource is Polygon && Polygon != null)
                {
                    Polygon.Opacity = 1;
                    Polygon = null;
                    Shape s = (Shape)e.OriginalSource;
                    Polygon = (Polygon)s;
                    Polygon.Opacity = 0.75;
                }
                else if (Polygon != null)
                {
                    Polygon.Opacity = 1;
                    Polygon = null;
                }
            }
            else
            {
                if(Polygon != null)
                    Polygon = null;
            }
        }
