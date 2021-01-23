    private void CreateTaskPane<T>(string title) where T : UserControl, new()
    {
       var taskPaneView = new T();
       taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(taskPaneView, title);
       taskPane.Visible = true;
    }
    // Later on..
    CreateTaskPane<CalenderTaskPane>("Calender");
