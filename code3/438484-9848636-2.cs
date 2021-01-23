        public void populateButtons()
        {
            double xPos;
            double yPos;
            UniformGrid grid = new UniformGrid();
            viewbox1.Child = grid;
            Random ranNum = new Random();
            foreach (var routedEventHandler in new RoutedEventHandler[] { button1Click, button2Click, button3_Click })
            {
                Button foo = new Button();
                Style buttonStyle = Window.Resources["CurvedButton"] as Style;
                int sizeValue = 100;
                foo.Width = sizeValue;
                foo.Height = sizeValue;
                xPos = ranNum.Next(200);
                yPos = ranNum.Next(250);
                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);
                foo.Style = buttonStyle;
                foo.Click += routedEventHandler;
                grid.Children.Add(foo);
            }
        }
