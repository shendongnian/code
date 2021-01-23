    void someFunc(object obj1) {
    	using (var ctx = getContext()) {
    		var list = ctx.MyTable
    			.Where ( .... )
    			.OrderBy( ... )
    			.AsEnumerable() // <-- Everything below is not translated to SQL.
    			.Select(x => new PocoObject {
    				string = x.String,
    				....
    				Command = new MyCommand { prop1 = x, objProp = obj1 }
    			})
    			.ToList();
    	}
    }
