    public static dynamic Convert(dynamic source, Type dest) {
        return Convert.ChangeType(source, dest);
    }
    myInstance = Convert(myInstance, MyType);
    // will result in myInstance being of type MyType.
