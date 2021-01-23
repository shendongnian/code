    RadPaneGroup paneGroup = new RadPaneGroup();
    RadPane pane = new RadPane();
    pane.Header = "WW1 Adventure";
    pane.Content = new ww1gamegrid();
    paneGroup.AddItem(pane, Telerik.Windows.Controls.Docking.DockPosition.Center);
