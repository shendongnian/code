    public void ClearLabel(Control control)
    {
       if (control is Label)
       {
           Label lbl = (Label)control;
           if (lbl.Text.StartsWith("label"))
               lbl.Text = String.Empty;
                
       }
       else
           foreach (Control child in control.Controls)
           {
               ClearLabel(child);
           }
    }
