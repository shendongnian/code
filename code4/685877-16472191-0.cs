    string s = "((4886.03 12494.89 \"LYR3_SIG2\"))";
    s = s.Replace("(", string.Empty).Replace(")", string.Empty);
    string[] arr = s.Split(' ');
    
    currentAddPla.Bows.Add(new BowTies() { 
       XCoordinate = Convert.ToDouble(arr[0]),
       YCoordinate = Convert.ToDouble(arr[1]),
       Layer = arr[3]});
