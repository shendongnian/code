    public event EventHandler Approved;
    public event EventHandler Cleared;
    public event EventHandler Canceled;
     protected void signatureApprove_clicked(object sender, EventArgs e)
    {
        if(Approved != null)
        Approved(this, EventArgs.Empty);
         
    }
    protected void sigClear_clicked(object sender, EventArgs e)
    {
            if (Cleared != null)
            Cleared(this, EventArgs.Empty);
    }
    protected void sigCancel_clicked(object sender, EventArgs e)
    {
           if (Canceled != null)
           Canceled(this, EventArgs.Empty);
    }
