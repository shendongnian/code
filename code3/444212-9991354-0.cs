     TabControl tbcEditor = new TabControl();
     //Get rid off this line --- TabPage tbPage = new TabPage();
     //Get rid off this line --- RichTextBox rtb = new RichTextBox();
      
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
    
          	//RichTextBox 
          	var rtb = new RichTextBox();
    
          	tbPage.Controls.Add(rtb);
          	rtb.Dock = DockStyle.Fill;
          	tbcEditor.TabPages.Add(tbPage); 
     }
