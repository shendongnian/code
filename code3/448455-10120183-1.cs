    private void btnMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            sbShowMenuButton.Completed += new EventHandler(sbShowModels_Completed);
            Storyboard.SetTarget(sbShowMenuButton, ((Button)ugModels.Children[ModelsAnimateIndex]));            
            sbShowMenuButton.Begin();
        } 
