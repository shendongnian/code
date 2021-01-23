    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
    MyDynamic.B = "asfaf";
    MyDynamic.C = 123;
    MyDynamic.MyMethod = new Func<int>(() => 
    { 
        return 55; 
    });
    Console.WriteLine(MyDynamic.MyMethod());
