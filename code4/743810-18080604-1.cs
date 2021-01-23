    public void SomeMethod()
    {
        var ClassFromDll = new ReferencedDll.SomeClass(ConnectionString.DataBase1.ToString());
        ClassFromDLL.DoSomething();
     }
