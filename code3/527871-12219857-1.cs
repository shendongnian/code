    ResourceManager resmgr = new ResourceManager("YourApplication.YourBaseResourceFile ", 
                                  Assembly.GetExecutingAssembly());
    
    protected void cv1_Validate(object source, ServerValidateEventArgs e) 
    {   
      
    if (FalseCondition)  
       {  
           CultureInfo ci = Thread.CurrentThread.CurrentCulture;	
           String str = resmgr.GetString("Error Msg Key in Resource File");
           cv1.ErrorMessage =str;      
           e.IsValid = false; 
        }     
    else   
      {   
         e.IsValid = true;  
       } 
    } 
