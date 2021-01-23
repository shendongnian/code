    public List<string> myList
    {
         get
         {
             return Session["MyData"] ?? (Session["MyData"] == new List<string>());
         }
    
         set 
         { 
             Session["MyData"] = value; 
         }
    }
