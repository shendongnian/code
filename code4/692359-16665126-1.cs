    partial void ScreenName_Activated()
    {
        IContentItemProxy proxy = this.FindControl("NameOfGrid");
    
        proxy.ControlAvailable += new EventHandler<ControlAvailableEventArgs>((s1, e1) =>
            {
                DataGrid dataGrid = (DataGrid)e1.Control;
        
                dataGrid.Columns[0].Visibility = System.Windows.Visibility.Collapsed;
                dataGrid.Columns[1].Visibility = System.Windows.Visibility.Collapsed;
            });
    }
