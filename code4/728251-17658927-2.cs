    double lowest_price;
    if (list1.Any()){
    	lowest_price = Double.MaxValue;
    	foreach(Cars a in list1){
    		if(a.price <= lowest_price){
    			lowest_price = a.price;
    			Console.WriteLine(a.price);
    		}
    	}//end of loop
    }
    else{
    	lowest_price = 0;
    }
