    void Main() {
    	var requirements = new [] {
    		new NameCount{ Name = "A", Count = 0 },
    		new NameCount{ Name = "B", Count = 0 },
    		new NameCount{ Name = "C", Count = 9 },
    		new NameCount{ Name = "D", Count = 3 },
    		new NameCount{ Name = "D", Count = 5 },
    	};
    
    	var candidates = new[] {
    		new NameCount {Name = "B", Count = 0},
    		new NameCount {Name = "C", Count = 1},
    		new NameCount {Name = "A", Count = 0}, 
    		new NameCount {Name = "D", Count = 2},
    		new NameCount {Name = "C", Count = 4},
    		new NameCount {Name = "C", Count = 4}
    	};
    	
    	var matched = requirements
    	    .GroupBy(r => r.Name)
    	    .GroupJoin(candidates, rg => rg.Key, c => c.Name, 
                (rg, cg) => new { requirements = rg, candidates = cg });
        bool satisfied = matched.All( /* ??? */ );
    }
    
    struct NameCount {
    	public string Name;
    	public int Count;
    }
