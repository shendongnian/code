    /// <summary>
    /// Recovers this instance of the form.
    /// </summary>
    public void RestoreFromTray()
    {
       if(this.InvokeRequired)
       {
          this.Invoke(new Action(RestoreFromTray) );
          return;
       }
       this.Visible = true;
       this.WindowState = FormWindowState.Normal;
       this.Activate();
    }
