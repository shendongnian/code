    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
       var taskPaneContainer = new TaskPaneContainer();
       var taskPane = this.CustomTaskPanes.Add(taskPaneContainer, "My Task Pane");
       taskPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionRight;
       taskPane.DockPositionRestrict = MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoChange;
       taskPane.Visible = true;
    }
