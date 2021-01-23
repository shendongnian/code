    var query = Query.And(
                  Query.EQ("color", "red"), 
                  Query.EQ("size", "large"), 
                  Query.GT("cost", 3)
                );
