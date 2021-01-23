    private void ToolPathGridView_Loaded( object sender, RoutedEventArgs e )
    {
        ToolPathGridView.ItemContainerGenerator.StatusChanged += new EventHandler(ItemContainerGenerator_StatusChanged);
    }
     void ItemContainerGenerator_StatusChanged( object sender, EventArgs e )
    {
        if ( ToolPathGridView.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated )
        {
            int i = 0;
            if ( ViewModel!=null )
            {
                i = ViewModel.SelectedIndex;
            }
            ToolPathGridView.SelectedIndex = 0;
            DataGridRow r = ToolPathGridView.ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;
            if ( r != null )
            {
                r.IsSelected = false;
                r.IsSelected = true;
            }
        }
    }
