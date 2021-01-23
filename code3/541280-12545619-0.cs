    public Planet(string planetName,string planetLocation,string distance) 
    { 
        if (string.IsNullOrEmpty(planetName))  
             throw new ArgumentNullException("Name cannot be Null"); 
    
        Name = planetName; 
        // More code lines
    } 
     
    public String Name {get; private set; }
