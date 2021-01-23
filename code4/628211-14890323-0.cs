    private void AggiornaContatore()
    {
        MethodInvoker inv = delegate 
        {
          this.lblCounter.Text = this.index.ToString(); 
        }
        
        if(!this.IsDisposed)
             this.Invoke(inv);
    }
