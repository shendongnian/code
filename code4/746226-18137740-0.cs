    public static class Implement{
    	public static dynamic Interface(object source){
    		return Impromptu.ActLike(source);
    	}
    }
    
    public static class Function{
    
    	public static Func<dynamic> Create(Func<dynamic> del){
    		return del;
    	}
    	
    	public static Func<dynamic,dynamic> Create(Func<dynamic,dynamic> del){
    		return del;
    	}
    	public static Func<dynamic,dynamic,dynamic> Create(Func<dynamic,dynamic, dynamic> del){
    		return del;
    	}
    	
    	public static Func<dynamic,dynamic,dynamic,dynamic> Create(Func<dynamic,dynamic, dynamic,dynamic> del){
    		return del;
    	}
    	//...Add more if you want
    }
