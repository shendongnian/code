    public event Action MyAction
    {
        add 
        { 
             SomeLibraryClass.StaticAction += value;
        }
        remove
        { 
             SomeLibraryClass.StaticAction -= value;
        }
    }  
