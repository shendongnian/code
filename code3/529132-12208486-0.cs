    class Potion {
    	public string Name;
    	public int Color;
    }
    
    class PotionNameEqualityComparer : IEqualityComparer<Potion> {
    	public bool Equals(Potion p1, Potion p2) {
    		return p1.Name.Equals(p2.Name);
    	}
    	public int GetHashCode(Potion p1) {
    		return p1.Name.GetHashCode();
    	}
    }
    void Main() {
    	var d = new Dictionary<Potion, int>(new PotionNameEqualityComparer());
    	var p1 = new Potion() { Name = "Health", Color = 1 };
    	var p2 = new Potion() { Name = "Health", Color = 2 };
    	d.Add(p1, 1);
    	d[p2]++; // works, and now you have two health potions. 
                 // Of course, the actual instance in the dictionary is p1; 
                 // p2 is not stored in the dictionary.    
    }           
