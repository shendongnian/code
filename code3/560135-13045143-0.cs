    if (CodeClass.InsertData(txtFirstName.Text, txtLastName.Text, Gender) == true)
         {
           HttpContext.Current.Items["A"]= "Inserted Successfully";
    
              Server.Transfer("OtherPage.aspx);
         }
    
    
    
    string ContextData =(string) HttpContext.Current.Items["A"];
    
    if(!string.Empty(ContextData))
    {  
    Label1.Text = ContextData;
    }
