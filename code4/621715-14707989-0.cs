     public void RecursiveChange(Control control)       
     {
        foreach (Control ctrl in control.Controls)
        {
           RecursiveChange(ctrl);
           ctrl.Text = "sherif";
        }
     }
      
