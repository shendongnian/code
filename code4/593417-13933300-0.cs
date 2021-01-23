    public void generic_NewFrame(object sender, NewFrameEventArgs e)
    {
      // Lets skip this callback if our form already closed
      **if (this.IsDisposed) return;**
    
      ...
      if (pictureBox1.InvokeRequired)
      {                            
    >>>   pictureBox1.Invoke(new MethodInvoker(delegate()
                             {                                                       
                               pictureBox1.BackgroundImage = (Image)buf;
                             }));
      }
      else
      {
        pictureBox1.BackgroundImage = (Image)buf;
      }
      ...
    }
