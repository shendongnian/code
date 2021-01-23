    public static void Main()
    {
        MyClass targetObject = new MyClass();
    
        var value = targetObject.GetType().GetField("BubblegumA").GetValue(targetObject, null);
    
        //value should = Strawberry
    }
