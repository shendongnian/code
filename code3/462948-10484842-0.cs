    public enum MyEnum : Int32
    {
        member1 = 0 //no good
    }
    public enum MyEnum : int
    {
        member1 = 0 //all is well
    }
