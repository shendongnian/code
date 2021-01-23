            for (int i = 0; i < 5; i++)
            {
                stackPanel1.Children.Add(new Ellipse 
                {
                    // left, top, right, bottom
                    Margin = new Thickness(0, 0, 20, 0),
                    Width = 20, Height = 20, 
                    Fill = new SolidColorBrush(Colors.Red)
                });
            }
