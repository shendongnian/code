    public static int UserId = 10; // BAD! everyone gets/sets this field's value
    // BAD! everyone gets/sets this property's implicit backing value
    public static int UserId {
         get;
         set;
    }
    
    // This case is fine; just a shortcut to avoid instantiating an object.
    // The backing value is segregated by other means, in this case, Session.
    public static int UserId{
        get{
            return (int)Session["UserId"];
        }
    }
    // While I would question doing work inside a property getter, the fact that 
    // it is  static won't cause an issue; every call retrieves data from a 
    // database, not from a single memory location.
    public static int UserId{
        get{
            // return some value from database
        }
    }
