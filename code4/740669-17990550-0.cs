    bool isClosing = false;
     private void Ana_FormClosing(object sender, FormClosingEventArgs e) 
        {            
            if(isClosing)
            {
               e.Cancel = true; 
               this.Hide();          
            }
        }
 
 
    private void kapatToolStripMenuItem_Click(object sender, EventArgs e) //Close
        {
            DialogResult ext;
            isClosing = true;
    
            ext = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ext == DialogResult.Yes)
            {
                Application.Exit();
    
            }       
        }
