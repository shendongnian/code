    public enum Colors
    {
       red, blue, green
    }
    
    Set<Colors> sc = new Set<Colors>();
    sc.Add(Colors.red);
    sc.Add(Colors.green);
    
    Set<Colors> sc2 = new Set<Colors>();
    sc2.Add(Colors.blue);
    
    sc.Add(sc2); // union
    
    Console.WriteLine(sc); // prints: [red,blue,green]
