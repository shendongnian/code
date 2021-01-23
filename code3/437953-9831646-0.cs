    private void DisplayButtonText(ControlCollection page)
    {
       foreach (Control c in page)
       {
          if(((Button)c).ID == "a")
          {
             Response.Write(((Button)c).Text);
             return null;
          }
          if(c.HasControls())
          {
             DisplayButtonText(c.Controls);
          }
    }
