    void Main()
    {
    List<One> l = new List<One>();
    l.Add(new One {Name = "Manoj", Address = "ktm", PhoneNo = "980123", IsPrimary = true});
    l.Add(new One {Name = "Manoj", Address = "ktm", PhoneNo = "980124", IsPrimary = false});
    l.Add(new One {Name = "Manoj", Address = "brt", PhoneNo = "980133", IsPrimary = true});
    l.Add(new One {Name = "Manoj", Address = "brt", PhoneNo = "980134", IsPrimary = false});
    l.Add(new One {Name = "Saroj", Address = "pkh", PhoneNo = "980121", IsPrimary = true});
    List<Two> t;
    t = l.GroupBy 
     (
     	x => x.Name
     )
     .Select 
     (
     	x => 
    	new Two 
    	{
		Name = x.Key, 
		Info = l.Where(z => z.Name == x.Key)
				.GroupBy (
				z => new 
				{
					z.Name,
					z.Address
				})
				.Select 
				(
					z => new Three 
					{
						Address = z.Key.Address, 
						Detail = l.Where
						(
							d => d.Name == z.Key.Name && d.Address == z.Key.Address
    						)
    						.GroupBy 
    						(
    							d => new
    							{
    								d.Name,
    								d.Address,
    								d.PhoneNo
    							}
    						)
    						.Select 
    						(
    							d => new Four 
    							{
    								PhoneNo = d.Key.PhoneNo, 
    								IsPrimary = d.SingleOrDefault().IsPrimary
    							}
    						).ToList()
    					}
    				).ToList()
    	}
    ).ToList();
    }
    class One
    {
     public string Name { get; set; }
     public string Address {get;set;}
     public string PhoneNo {get;set;}
     public bool IsPrimary {get;set;}
    }
    class Two
    {
     public string Name {get;set;}
     public List<Three> Info {get;set;}
    }
    class Three
    {
     public string Address {get;set;}
     public List<Four> Detail {get;set;}
    }
    class Four
    {
     public string PhoneNo {get;set;}
     public bool IsPrimary {get;set;}
    }
