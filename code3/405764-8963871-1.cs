    public static void Main()
    {
        A a = new A();
        a.Bar(); // prints A.Bar
        (a as IFoo).Bar(); // prints IFoo.Bar
        (a as IBaz).Bar(); // prints IBaz.Bar
        (a as IQux).Bar(); // prints IBaz.Bar
    }
