    private void attachClickEventHandler()
    {
      for (int i = 0; i < 10; i++)
      {
         Panel p = new Panel();
         p.Click+=p_Click;
         flowLayoutPanel1.Controls.Add(p);
      }
    
    // OR
    
      foreach(Control c in flowLayoutPanel1.Controls)
         if(c is Panel)
            c.Click += p_Click;
    }
    
    void p_Click(object sender, EventArgs e)
    {
       // do click stuff
    }
