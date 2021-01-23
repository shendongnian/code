    var wp = new WrapPanel
        {
            Orientation = System.Windows.Controls.Orientation.Vertical,
            Height = 400
        };
    wp.Children.Add(new Button { Content = "A", BorderBrush = new SolidColorBrush(Colors.Cyan) }); // Cyan is the same as Aqua
    wp.Children.Add(new Button { Content = "B", BorderBrush = new SolidColorBrush(Color.FromArgb(255, 95, 158, 160)) }); // CadetBlue
    wp.Children.Add(new Button { Content = "C", BorderBrush = new SolidColorBrush(Color.FromArgb(255, 139, 0, 139)) }); // DarkMagenta
    wp.Children.Add(new Button { Content = "D", BorderBrush = new SolidColorBrush(Colors.Magenta) }); // Fuschia is the same as Magenta
    wp.Children.Add(new Button { Content = "F", BorderBrush = new SolidColorBrush(Color.FromArgb(255, 173, 216, 230)) }); // LightBlue
    wp.Children.Add(new Button { Content = "G", BorderBrush = new SolidColorBrush(Colors.Orange) });
    this.LayoutRoot.Children.Add(wp);
