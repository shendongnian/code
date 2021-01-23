    private bool _ForceClose = false; 
    public void ForceClose()
    {
        _ForceClose = true; 
        this.Close(); 
    }
    
    private void MemberForm_FormClosing(object sender, FormClosingEventArgs e) 
    {
       if(!_ForceClose)
       {
           e.Cancel = true;
           Hide();
       }
    }
