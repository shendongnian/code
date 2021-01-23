    if(!RequiredFieldValidator1.IsValid){
        //You might have to adjust where its looking for the control
        TextBox txt = form1.FindControl(RequiredFieldValidator1.ControlToValidate) as TextBox;
        if (txt != null)
        {
            txt.CssClass = "txtbox300Comment";
        }
    
    }
