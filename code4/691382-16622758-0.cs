    private void FormIsClosing(object sender, FormClosingEventArgs e)
    {
       var owner = this.Owner;
    
       if (owner != null)
       {
           owner.Show();
       }
    }
