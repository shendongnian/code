    public void MainMethod()
    {
        // Here you would like to call the static constructor
    
        // The first access to the class forces the static constructor to be called.
        object temp1 = MyStaticClass.AnyField;
        // or
        object temp2 = MyClass.AnyStaticField;
    }
