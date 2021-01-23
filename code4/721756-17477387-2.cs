    List<OBJ> _source = new List<OBJ>() 
    	{
    		new Projectiles{ Name = "Projectile A"},
    		new Projectiles{ Name = "Projectile B"},
    		new Projectiles{ Name = "Projectile C"},
    		new Particles { Name = "Particle A"},
    		new Particles { Name = "Particle B"},
    		new Particles { Name = "Particle C"},
    	};
    
    var query = (from a in _source
    			 group a by a.GetType() into b
    			 select new
    			 {
    				 EntityName = b.Key.ToString().Split('.').Last().Substring(0, 1).ToUpper() + b.Key.ToString().Split('.').Last().Substring(1).ToLower(),
    				 Entities = b.OrderBy(a => a.Name).ToList()
    			 }).ToDictionary(kvp => kvp.EntityName, kvp => kvp.Entities);
    
    treeView1.DataContext = query;
