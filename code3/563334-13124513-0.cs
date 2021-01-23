    TabPage tp = new TabPage();
    //create controls and set their properties
    Button btn1 = new Button();
    btn1.Location = new Point(10,10);
    btn1.Size = new System.Drawing.Size(30,15);
    //add control to the TabPage
    tp.Controls.Add(btn1);
    //add TabPage to the TabControl
    tabControl1.TabPages.Add(tp);
