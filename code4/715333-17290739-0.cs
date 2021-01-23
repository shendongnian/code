    public class bClass {
    	public bClass(bClass source) {
    		// TODO: Null check
    		id = source.id;
    		name = source.name;
    	}
    	
        public int id {get; set;}
        public string name {get; set;}
    }
    
    public class dClass : bClass {
    	public dClass(bClass source, int extraVal): base(source) {
    		// TODO: Null check
    		extraVal = extraVal;
    	}
    	
        public int extraVal {get; set;}
    }
    
    List<bClass> baseClassList = getBaseClassList();
    List<dClass> dClassList = bClassList.ConvertAll(x => new dClass(x, exVal));
