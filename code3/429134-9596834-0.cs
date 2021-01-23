    using (MyClass o = new MyClass())
    {
        TheClassIWantMyClassToSee x = new TheClassIWantMyClassToSee();
        try
        {
            x.DoStuff();
        }
        finally
        {
            // Do stuff here
        }
    }
