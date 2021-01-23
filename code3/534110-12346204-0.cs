    private static SomeEnum myEnum;
    
    public static void SetSomeEnum(SomeEnum value){
        myEnum = value;
    }
    public static SomeEnum SetSomeEnum(SomeEnum value){
        return myEnum;
    }
