        public static BitmapSource CreateImage(string text, double width, double heigth)
        {
            // create WPF control
            var size = new Size(width, heigth);
            var stackPanel = new StackPanel();
            var header = new TextBlock();
            header.Text = "Header";
            header.FontWeight = FontWeights.Bold;
            var content = new TextBlock();
            content.TextWrapping = TextWrapping.Wrap;
            content.Text = text;
            stackPanel.Children.Add(header);
            stackPanel.Children.Add(content);
            // process layouting
            stackPanel.Measure(size);
            stackPanel.Arrange(new Rect(size));
            // Render control to an image
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)stackPanel.ActualWidth, (int)stackPanel.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(stackPanel);
            return rtb;
        }
