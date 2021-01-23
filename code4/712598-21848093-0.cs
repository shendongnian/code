        private MessageBoxResult isBlaBlaa()
        {
            Window w = new Window();
            w.Tag = MessageBoxResult.Cancel;
            Grid grid = new Grid();
            grid.Margin = new Thickness(30);
            grid.Children.Add(new TextBlock()
            {
                Text = "Bla blaa",
                Margin = new Thickness(0, 0, 0, 20)
            });
            
            Button btn;
            btn = new Button()
            {
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                Content = "Cancel",
                Width = 100,
                Height = 30,
            };
            btn.Click += new RoutedEventHandler((object sender, RoutedEventArgs e) => { w.Tag = MessageBoxResult.Cancel; w.DialogResult = false; });
            grid.Children.Add(btn);
            
            btn = new Button()
            {
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Content = "No",
                Width = 100,
                Height = 30,
            };
            btn.Click += new RoutedEventHandler((object sender, RoutedEventArgs e) => { w.Tag = MessageBoxResult.No; w.DialogResult = false; });
            grid.Children.Add(btn);
            
            btn = new Button()
            {
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                Content = "Yes",
                Width = 100,
                Height = 30,
            };
            btn.Click += new RoutedEventHandler((object sender, RoutedEventArgs e) => { w.Tag = MessageBoxResult.Yes; w.DialogResult = true; });
            grid.Children.Add(btn);
            w.Content = grid;
            w.ShowDialog();
            return (MessageBoxResult)w.Tag;
        }
