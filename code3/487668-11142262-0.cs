    public static void DontModify(MyClass a)
    {
        MyClass clone = (MyClass)a.Clone();
        clone.SomeIntProperty+= 100;// Do something more meaningful here
        return;
    }
