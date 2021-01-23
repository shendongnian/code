    var nas = "046 454 286".Where(x => !Char.IsWhiteSpace(x)).ToList();
    var check = "121 212 121".Where(x => !Char.IsWhiteSpace(x)).ToList();
    
    var result = "";
    for(int i = 0; i < nas.Count(); ++i){
    	int tmp = (int)(nas[i]) * (int)(check[i]);
    	var val = tmp < 10 ? tmp : tmp - 9;
    	result += val;
    }
    
    var sum = result.Aggregate(0, (acc, item) => acc + (int)(item));
    if(sum % 10 == 0) Console.WriteLine("valid!"); else Console.WriteLine("invalid!");
