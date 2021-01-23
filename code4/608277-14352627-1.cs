    var	resultSet 	= 	from a in dtbl1.AsEnumerable()
    					join b in dtbl2.AsEnumerable()
    						on a.ID equals b.LinkID
    					group a by new
    						{
    							a.Name,
    							a.Age,
    							a.ID
    						} into g
    					select new
    						{
    							g.Key.Name,
    							g.Key.Age,
    							g.Key.ID,
    							g.Count()
    						};
