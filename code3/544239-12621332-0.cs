    tabControl1.TabPages.Clear();
    
    var newPanelButton = new Button() {
        Text = "0% Complete",
        Location = new Point(117, 75),
        Height = 80,
        Width = 200
    };
    
    var tabPage = new TabPage();
    tabPage.Controls.Add(newPanelButton);
    
    tabControl1.TabPages.Add(tabPage);         
   
