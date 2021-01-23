    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {      
        this.Close();
    }
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
       if ( this.Owner != null )
         this.Owner.Close();
    }
