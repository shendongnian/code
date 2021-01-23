    void Main()
    {
       bool findFootballers   = true;
       bool findVolleyBallers = false;
    
       var Fathers = new List<Father>()
       {
          new Father() { Name = "Frank SR", Sons = new List<Son>() { new Son() { Name = "Bob", PlaysFootball = true }, new Son() { Name = "Frank", PlaysVolleyBall = true } } },
          new Father() { Name = "Knute", Sons = new List<Son>() { new Son() { Name = "Mean Jo Green", PlaysFootball = true }, new Son() { Name = "McMann", PlaysFootball = true } } }
       };
    
    
       Fathers.Where (f => (findFootballers == false) ? true : f.Sons.Any (s => s.PlaysFootball == true))
              .Where (f => (findVolleyBallers == false) ? true : f.Sons.Any (s => s.PlaysVolleyBall == true))
              .Select( f => new
                           {
                           Name = f.Name,
                           TargetSportSons = string.Join(", ", f.Sons
                                                                .Where (s => (findFootballers == false) ? true : s.PlaysFootball)
                                                                .Where (s => (findVolleyBallers == false) ? true : s.PlaysVolleyBall)
                                                                .Select (s => s.Name))
                           }
                     )
                .ToList()
                .ForEach(fs => Console.WriteLine ("Father {0} has these sons {1} who play {2}", fs.Name, fs.TargetSportSons, (findFootballers ? "Football" : "VolleyBall ")));
    
    // Output
    // Father Frank SR has these sons Bob who play Football
    // Father Knute has these sons Mean Jo Green, McMann who play Football
    
    }
    
    public class Son
    {
       public string Name { get; set; }
       public bool PlaysFootball { get; set; }
       public bool PlaysVolleyBall { get; set;}
    }
    
    
    public class Father
    {
       public string Name { get; set; }
       public List<Son> Sons = new List<Son>();
    
    }
    
    // Define other methods and classes here
