    using System.Reflection;
    
    Assembly dll= Assembly.Load("DALL"); //DALL name of your assembly
    Type MyLoadClass = dll.GetType("DALL.LoadClass"); // name of your class
     object  obj = Activator.CreateInstance(MyLoadClass)
