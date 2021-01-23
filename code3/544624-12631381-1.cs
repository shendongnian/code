    class CustomChild{
    
       public string Name {get; set;}
       public int ID { get; set ;}
    
    
    }
    
    List<CustomChild> children = new List<CustomChild>();
    
     foreach (Child c in listfromDB)
    {
          
          children.Add(new CustomChild{ Name = c.Name, ID = c.ID} );
    
    }
