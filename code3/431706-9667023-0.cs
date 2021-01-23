    // Define the predicate inline:
    var results = list.Where(b => b.A.Name == "Fred");
    
    // or if you have the predicate defined separately:
    var results = list.Where(b => predicate(b.A));
