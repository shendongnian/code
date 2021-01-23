	  var query = from aProp in a.GetType().GetProperties()
                  let aValue = aProp.GetValue(a)
				  let bProp = b.GetType().GetProperty(aProp.Name)
				  let bValue = bProp.GetValue(b)
				  where !aValue.Equals(bValue)
				  select new { aProp.Name, aValue, bValue };
				  
	  var allTheSame = !query.Any();
