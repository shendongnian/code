    public ClassA getObject(int i)
    {
        if(i == 1)
        {
            ClassB objB = new ClassB();
            return objB;
        }
        else
        {
            ClassC objC = new ClassC();
            return objC;
        }
    }
    public static void main()
    {
        var obj = getObject(5);
        if (obj is ClassB)
        {
            obj.aValue = 20;
            obj.bValue = 30;
            //obj.cValue = 40; this wont work since obj is of type ClassB
        }
        //or 
        var obj = getObject(5);
        if (obj is ClassC)
        {
            obj.aValue = 20;
            //obj.bValue = 30; this wont work since obj is of type ClassC
            obj.cValue = 40; 
        }
    }
