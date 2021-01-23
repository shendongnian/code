    System.Windows.Forms.Timer first = new System.Windows.Forms.Timer();
    first.Tick += tick;
    
    System.Windows.Forms.Timer second = new System.Windows.Forms.Timer();
    second.Tick += tick;
    
    private void tick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
