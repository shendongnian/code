    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
    MyDynamic.A = "A";
    MyDynamic.B = "B";
    MyDynamic.C = "C";
    MyDynamic.Number = 12;
    MyDynamic.MyMethod = new Func<int>(() => 
    { 
        return 55; 
    });
    Console.WriteLine(MyDynamic.MyMethod());
