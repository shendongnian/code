    private void DoIt()
    {
        // The code from the toolStripButton1_Click handler
    }    
    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        DoIt();
    }
    
    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ofdSelectMedia.ShowDialog() == DialogResult.OK)
            switch(ofdSelectMedia.FilterIndex){
                case 1: new ImageViewer().Show(); 
                    DoIt();
                    break;
                case 2: new AudioPlayer().Show();
                    break;
                case 3: new VideoPlayer().Show();
                    break;
       }
    }
