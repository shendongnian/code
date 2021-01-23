    //in your form
    public bool AllowClose {get;set;}
    private void Ana_FormClosing(object sender, FormClosingEventArgs e) 
    {
        if(!AllowClose)
        {            
            e.Cancel = true; 
            this.Hide();  
        }        
    }
    //in your context menu event
    private void kapatToolStripMenuItem_Click(object sender, EventArgs e) //Close
    {
        DialogResult ext;
        ext = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (ext == DialogResult.Yes)
        {
            this.AllowClose = true;
            Application.Exit();
        }       
    }
