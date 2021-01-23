        void Main()
    {
    string item1 = "test1";
    string item2 = "test2";
    
    ArrayList someList = new ArrayList();
    someList.Add(item1);
    someList.Add(item2);
    
    item1.Dump();
    item2.Dump();
    
    someFunc(someList);
    
    item1.Dump();
    item2.Dump();
    
    someList.Dump();
    }
    
    public void someFunc(ArrayList parameters)
    {
    	parameters[0] = "Monkeys";
    	parameters[1] = "More Monkeys";
    }
