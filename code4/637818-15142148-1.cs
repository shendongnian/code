    private void Button_Click(object sender, RoutedEventArgs e)  
    {  
        (sender as Button).ContextMenu.IsEnabled = true;  
        (sender as Button).ContextMenu.PlacementTarget = (sender as Button);  
        (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;  
        (sender as Button).ContextMenu.IsOpen = true;  
    } 
