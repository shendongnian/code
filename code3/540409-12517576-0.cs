        //You declare as global variable of your class        
        public WebControl control{get;set};
        ....
        //Your code inside method
        switch (_inputType)
        {
            case code.enums.inputType.textBox:
                control= new TextBox();
                //Here you can set global property
                control.Id = ""; //etc.
                break;
            case code.enums.inputType.dropDownList:
                control= new DropDownList();
                break;
            case code.enums.inputType.checkBox:
                control = new CheckBox();
                break;
        }
    
    
    //For Specific property
    
    var test = (TextBox)control;
    //Add specific property.
 
