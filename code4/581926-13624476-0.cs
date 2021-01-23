    struct Mutable
    {
    	public int X {get; set;}
    	public void ChangeX(int x) { X = x; }
    }
    
    var mutables = new List<Mutable>{new Mutable{ X = 1 }};
    foreach(var item in mutables)
    {
      // Illegal!
      item = new Mutable(); 
    
      // Illegal as well!
      item.X++;
    }
