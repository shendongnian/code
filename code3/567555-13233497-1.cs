    var outer = PredicateBuilder.True<Entity>();
    
    switch (status) {
            case "0":
                outer = outer.And (p => p.status<0);
                break;
            case "-1":
                outer = outer.And (p => p.status==-1);
                break;
            case "-100":
                outer = outer.And (p => p.status==-100);
                break;
            case "1":
            default:
                outer = outer.And (p => p.status>=0); 
                break;
        }
    
    if (strsearch != "")
            outer = outer.And (p => p.desc.Contains(strsearch ));
    dataContext.Entity.Where (outer );
