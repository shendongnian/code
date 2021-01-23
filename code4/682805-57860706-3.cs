        // You might e.g. call this in the constructor of DrawOnCanvas
        internal void DrawRectWithText()
        {
            var rect = new System.Windows.Shapes.Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = new SolidColorBrush(Colors.Beige);
            rect.Width = 100;
            rect.Height = 100;
            // Use Canvas's static methods to position the rectangle
            Canvas.SetLeft(rect, 100);
            Canvas.SetTop(rect, 100);
            var text = new TextBlock()
            {
                Text = task.Title,
            };
            // Use Canvas's static methods to position the text
            Canvas.SetLeft(text, 90);
            Canvas.SetTop(text, 90);
            // Draw the rectange and the text to my Canvas control.
            // DrawCanvas is the name of my Canvas control in the XAML code
            DrawCanvas.Children.Add(rect);
            DrawCanvas.Children.Add(text);
        }
