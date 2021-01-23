    void SetVisible(Control c)
    {
        if (control.Name == "your control name") 
              control.Visible = false; 
          
        foreach(Control control in c.Controls){       
          SetVisible(control);       
        }
        
    } 
