    // this button in the child form
    private void button1_Click(object sender, EventArgs e) {  
       ToolStripMenuItem tsm;
       // file menu
       tsm = (ToolStripMenuItem)this.MdiParent.MainMenuStrip.Items[0];
       MessageBox.Show( tsm.DropDownItems[0].Name);
       // first menu under File Menu
       tsm.DropDownItems[0].BackColor = Color.Red;
       // second menu under File Menu
       tsm.DropDownItems[1].BackColor = Color.Wheat;
    }
