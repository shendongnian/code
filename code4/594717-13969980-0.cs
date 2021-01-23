    List<Visit> visits = new List<Visit>();
    visits.Add(new Pickup{ ... some properties set here ...});
    visits.Add(new Delivery{ ... some properties set here ...});
    Console.WriteLine(visits[0].ToString()) // writes out a pickup
    Console.WriteLine(visits[1].ToString()) // writes out a delivery
