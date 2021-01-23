    private void btnReset_Click(object sender, System.EventArgs e) 
    { 
        for(int x = this.BackPanel.Controls.Count - 1; x >= 0; x--)
            this.BackPanel.Control.Remove(x);
        for(int x = 0; x < imgArray.Length; x++)
        {
            imgArray[x].Image = null;  
            imgArray[x] = null;
        }  
    } 
