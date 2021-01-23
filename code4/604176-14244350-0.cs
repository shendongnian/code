    var input = new[] {"moo", "*", "foo", "bar", "baz", "*", "roo", 
                       "moo", "*", "*", "hoot", "*", "boot"};
    	int index = 0;
        var output = input.Select( x => new
                     {
                       Item=x, 
                       GroupCondition = x =="*" ? ++index:index     // Introduce GroupCondition, Increase it if delimiter is found      
                     })
              .GroupBy((x)=>x.GroupCondition)                      // Group by GroupCondition
              .Select( x => x.Select( y => y.Item));                // Get rid of GroupCondition
