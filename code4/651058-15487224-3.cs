    using System.Windows.Forms.Integration;
...
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var form = new Form1();
            form.TopLevel = false;
            WindowsFormsHost host = new WindowsFormsHost();
            host.Child = form;
            host.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            host.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            grid.Children.Add(host);
        }
