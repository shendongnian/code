     private UserControl1 myUserControl1;
            private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;
    
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                myUserControl1 = new UserControl1();
                myCustomTaskPane = this.CustomTaskPanes.Add(myUserControl1, "My Task Pane");
               
            }
            public void toggle(bool b)
            {
                myCustomTaskPane.Visible = b;
            }
