    // dll1
    class myClass
    {
        ...
    }
    myClass GetMyClass()
    {
        ...
    }
    // dll2
    class myClass2
    {
        public myClass2(myClass c)
        {
            // instantiate myClass2 with values from myClass
        }
    }
    myClass2 GetMyClass()
    {
        // somehow get myClass and convert it to myClass2 here
    }
