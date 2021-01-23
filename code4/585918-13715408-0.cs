    class WpfSample
    {
        [STAThread]
        public static void Main()
        {
            var window = new Window()
            {
                Title = "WPF",
                Width = 640,
                Height = 480
            };
    
            var grid = new Grid();
                
            var button = new Button()
            {
                Content = "Click Me",
                Width = 100,
                Height = 50,
    
            };
    
            grid.Children.Add(button);
            window.Content = grid;
    
            button.Click += (s, e) =>
            {
                MessageBox.Show("You clicked me");
            };
    
            window.ShowDialog();
                
        }
    }
