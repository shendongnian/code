    You can use button postbackurl property where you need to specify your parent page  address and on the 
    parent page use the following code:
    let say you have a textbox on your popup, you can use the same as folows
    
    TextBox txtnew=(TextBox)PreviousPage.FindControl("id or name of control");
    
    and then use its value OR create a property on popup page like 
     
    public string popupdata
    {
       get; set;
    }
    popupdata=your poppage value;
    
    now access the same on parent page using 
    
    string str=PreviousPage.popupData.Tostring();
    
    
    OR you can use cookies or session as your other options.
    
     
