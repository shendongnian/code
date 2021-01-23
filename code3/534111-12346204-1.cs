    private static SomeEnum _myEnum;
    
    public static void SetSomeEnum(SomeEnum value){
        _myEnum = value;
    }
    public static SomeEnum SetSomeEnum(SomeEnum value){
        return _myEnum;
    }
