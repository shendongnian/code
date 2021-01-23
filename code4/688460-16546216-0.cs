    public Trigger(object targetObject, string methodName, params object[] parameters)
    {
        //"parameters" here will be an array of length 0 if no parameters were passed    
    }
    MyTrigger trigger = new MyTrigger(myObj, "Delete"); //no parameters
    MyTrigger trigger = new MyTrigger(myObj, "Delete", param1); //one parameter
    MyTrigger trigger = new MyTrigger(myObj, "Delete", param1, param2); //two parameters
