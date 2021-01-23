    public string Method1()
    {
        string status = "0";
        //Code - Exception may be thrown
        return "0";
    }
    string status = "0";
    ClassA ObjA = new ClassA();
    try
    {
         status = objA.Method1();
     }
     Catch(Exception Ex)
     {
         //Log Exception EX
        status = "-1;
     }
