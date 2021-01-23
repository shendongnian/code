    public dynamic FunctionOne()
    {
        //do some logic.
        //return myproject but only properties 4,5,6
        return new {property4 = "abc", property5 = "xyz", property6 = "123"};
    }
    public dynamic FunctionTwo()
    {
        //do some logic.
        //return myproject but only properties 1,2,3
        return new { property1 = "asdf", property2 = "123", property3 = "aaa" };
    }
