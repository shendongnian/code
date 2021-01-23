    class DynamicClass
    {
        public String DynamicObject;
    }
    
    public dynamic DynamicProperty
    {
        get
        {
            return Session["Dynamic"];
        }
        set
        {
            Session["Dynamic"] = value;
        }
    }
    
    DynamicClass d = new DynamicClass();
    d.DynamicObject = "Hi";
    dynamic Obj = d;
    DynamicProperty = Obj;
