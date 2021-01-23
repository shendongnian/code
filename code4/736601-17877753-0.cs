    interface IPrintable
    {
      string Name{get;}
    }
    
    class Cat : IPrintable
    {
      string Name{get{retrun "Dog";}}
    }
    
    void PrintName(IPrintable objectToPrint)
    {
      Console.WriteLine(objectToPrint.Name);
    }
    
    var cat = new Cat();
    PrintName(cat);
