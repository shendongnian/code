    for (int i = 1; i < some_number; i++) 
    {    
        Control myControl = FindControl("CheckBox" + i.ToString());
        if(myControl != null && myControl.GetType() == typeof(CheckBox)) 
        {
            ((CheckBox)myControl).ID = "chckbx_" + i.ToString();
            ((CheckBox)myControl).CssClass = "newClass";
        }
    }
