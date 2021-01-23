    Namespace.Form2 form2 = (Namespace.Form2)Application.OpenForms[1];
    
    //On Button event handler    
    private void onClick(object sender, EventArgs e)
    {
           form2.LableName.Visible = true; 
    }
    
    //off Button event handler    
    private void offClick(object sender, EventArgs e)
    {
           form2.LableName.Visible = false;
    }
