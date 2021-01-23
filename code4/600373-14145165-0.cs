    void Main()
    {
      string def = "#def xyz[timer=50, fill=10]";
      
      string [] inBracket = def.Split("[]".ToCharArray());
      
      string [] elements = inBracket[1].Split(",".ToCharArray());
      
      int timer = int.Parse(elements[0].Split("=".ToCharArray())[1]);
    
      int fill = int.Parse(elements[1].Split("=".ToCharArray())[1]);
    
      Console.WriteLine("timer = "+timer.ToString());
      Console.WriteLine("fill = "+fill.ToString());
      
    }
    
