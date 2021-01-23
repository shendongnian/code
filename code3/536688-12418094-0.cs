    Page_Init(object Sender, EventArgs e) 
    {
        TextBox txt = new TextBox(){
            ID = "txtName"    
        };
        plcDynamicControls.Controls.Add(txt); //Add to Form
        dynamicControls.Add(txt); //Add to reference list, to avoid having to do .FindControl()
        TextBox add1 = new TextBox(){
            ID = "txtAddress1"    
        };
        plcDynamicControls.Controls.Add(add1); 
        dynamicControls.Add(add1); 
        TextBox add2 = new TextBox(){
            ID = "txtAddress2"    
        };
        plcDynamicControls.Controls.Add(add2);
        dynamicControls.Add(add2); 
    }
