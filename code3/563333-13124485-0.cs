    var contentControl = new ContentControl ();    //This is what we will put all your content in
    contentControl.Dock = DockStyle.Fill;
    var page = new TabPage("Tab Text");    //the title of your new tab
    page.Controls.Add(contentControl);     //add the content to the tab
    TabControl1.TabPages.Add(page);        //add the tab to the tabControl
