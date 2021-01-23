    using System.Windows;
    
    namespace WpfApplication4
    {
        public partial class Window3 : Window
        {
            public Window3()
            {
                InitializeComponent();
            }
    
            private void MoveRight(object sender, RoutedEventArgs e)
            {
                if (Grid.Margin.Right <= 0)
                {
                    Grid.Margin = new Thickness(Grid.Margin.Left + 100,0,0,0);
                }
                else
                {
                    Grid.Margin = new Thickness(0, 0, Grid.Margin.Right - 100, 0);
                    Scr.ScrollToHorizontalOffset(Scr.HorizontalOffset - 100);
                }
            }
    
            private void MoveLeft(object sender, RoutedEventArgs e)
            {
                if (Grid.Margin.Left > 0)
                {
                    Grid.Margin = new Thickness(Grid.Margin.Left - 100, 0, 0, 0);
                }
                else
                {
                    Grid.Margin = new Thickness(0, 0, Grid.Margin.Right + 100, 0);
                    Scr.ScrollToHorizontalOffset(Scr.HorizontalOffset + 100);
                }
            }
        }
    }
