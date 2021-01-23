        //A List (with a maximum of 5 elements) of Lists of Units
        List<List<Model.Unit>> listOfUnits = m_hibernateSession
											.Query<Order>()
											.OrderByDescending(o=>o.PONumber)
											.Where(o => o.PONumber != 0)
											.Take(5)
											.Select(o => o.Units.ToList())
											.ToList();
        //OR, a List of all Units for the last 5 Orders
       List<Model.Unit> listOfUnits = m_hibernateSession
											.Query<Order>()
											.OrderByDescending(o=>o.PONumber)
											.Where(o => o.PONumber != 0)
											.Take(5)
											.SelectMany(o => o.Units)
											.ToList();
