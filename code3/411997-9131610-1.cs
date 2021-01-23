    int a = Convert.ToInt(Console.ReadLine());
    
    var abc = new Class();
    
    if (a == 1)
        abc = new Class1();
    else if (a == 2)
        abc = new Class2();
    else if (a == 3)
        abc = new Class3();
    
    public class Class { ... }
    public class Class1:Class{ ... }
    public class Class2:Class1{ ... }
    public class Class3:Class2{ ... }
