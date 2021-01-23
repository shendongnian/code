    private PictureBox PictureBoxOnContext;
    
    private void AddPicture_Click(object sender, EventArgs e)
    {
      PictureBox picBox = new PictureBox();   
      //Your code logic to add PictureBox to FlowLayout 
      
      picBox.MouseEnter += new EventHandler(PictueBox_MouseEnter);
    
    }
    
    void PictueBox_MouseEnter(object sender, EventArgs e)
    {
       PictureBoxOnContext = (PictureBox)sender;
    }
    
    
    private void AddDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (PictureBoxOnContext != null)
        {
            //Pass this PictureBoxOnContext to your preview window/ your opearations
    
    	PictureBoxOnContext = null;
            
        } 
    }
