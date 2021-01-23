     TabControl tbcEditor = new TabControl();
     //Get rid off this line --- TabPage tbPage = new TabPage();
     //Get rid off this line --- RichTextBox rtb = new RichTextBox();
     
     List<TabPage> _tabs = new  List<TabPage>();
     List<RichTextBox> _tbx = new  List<RichTextBox>();
      
     private void frmTextEditor_Load(object sender, EventArgs e) 
     {
          Controls.Add(tbcEditor);
          tbcEditor.Dock = DockStyle.Fill;
          
           AddNewTab();
     }
     
     private void newToolStripMenuItem_Click(object sender, EventArgs e) 
     {   
           AddNewTab();
     } 
     
     private void AddNewTab()
     {
     	//TabPage 
          	var tbPage = new TabPage();
          	_tabs.Add(tbPage);
    
          	//RichTextBox 
          	var rtb = new RichTextBox();
          	_tbx.Add(rtb);
    
          	tbPage.Controls.Add(rtb);
          	rtb.Dock = DockStyle.Fill;
          	tbcEditor.TabPages.Add(tbPage); 
     }
