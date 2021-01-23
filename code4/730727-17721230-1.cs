        private void UpdateOpactiyMask()
        {
            Point topLeft = new Point();
            Point bottomRight = new Point(image.ActualWidth, image.ActualHeight);
            GeometryDrawing left = new GeometryDrawing();
            left.Brush = borderBrush;
            left.Geometry = new RectangleGeometry(new Rect(topLeft, new Point(SelectedArea.Left, bottomRight.Y)));
            GeometryDrawing right = new GeometryDrawing();
            right.Brush = borderBrush;
            right.Geometry = new RectangleGeometry(new Rect(new Point(SelectedArea.Right, topLeft.Y), bottomRight));
            GeometryDrawing top = new GeometryDrawing();
            top.Brush = borderBrush;
            top.Geometry = new RectangleGeometry(new Rect(new Point(SelectedArea.Left, topLeft.Y), new Point(SelectedArea.Right, SelectedArea.Top)));
            GeometryDrawing bottom = new GeometryDrawing();
            bottom.Brush = borderBrush;
            bottom.Geometry = new RectangleGeometry(new Rect(new Point(SelectedArea.Left, SelectedArea.Bottom), new Point(SelectedArea.Right, bottomRight.Y)));
            GeometryDrawing center = new GeometryDrawing();
            center.Brush = selectionBrush;
            center.Geometry = new RectangleGeometry(SelectedArea);
            DrawingGroup drawing = new DrawingGroup();
            drawing.Children.Add(left);
            drawing.Children.Add(right);
            drawing.Children.Add(top);
            drawing.Children.Add(bottom);
            drawing.Children.Add(center);
            mask.Drawing = drawing;
        }
