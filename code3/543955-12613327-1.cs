    SetLabels (this);
    
    public void SetLabels(Control ctrl)
    {
      foreach (Control c in ctrl.Controls)
         {
             SetLabels(c);
             if (c is Label)
             {
                 if (c.Text == "12/31/1600")
                 {
                     c.Text = "Not Found";
                 }
             }
         }
    }
