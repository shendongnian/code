    delegate void DelMethod(string str = "hai");  
    static void Method(string str = "bye")
    {
        Debug.WriteLine(str);
    }
    
    DelMethod dm = Method;
    dm();
    //prints "hai"
