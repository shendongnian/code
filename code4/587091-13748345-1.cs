    public void OnMyMethod()
    {
         // has the event handler been assigned?
         if (this.UpdateProgress!= null)
         {
             // raise the event
             this.UpdateProgress(this, new EventArgs());
         }
    }
