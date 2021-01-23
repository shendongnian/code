    public ucType UserControlType {
       set {
          ViewState["UserControlType"] = value; 
       }
       get { 
          object o = ViewState["UserControlType"]; 
          if (o == null)
             return ucType.CustomersWhoHaveAContract; // default value
          else 
             return (ucType)o; 
       }
    }
