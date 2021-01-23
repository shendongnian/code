      <Button x:Name="ToggleButton" Click="ToggleButton_Click"></Button>
    
    
    
     private void ToggleButton_Click(object sender, RoutedEventArgs e)
            {
                if (Panel1.Visibility == System.Windows.Visibility.Visible)
                {
                    Panel2.Visibility = System.Windows.Visibility.Visible;
                    Panel1.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    Panel2.Visibility = System.Windows.Visibility.Collapsed;
                    Panel1.Visibility = System.Windows.Visibility.Visible;
                }
            }
