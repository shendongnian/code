    string baseStringOne = "Car is blue and new", baseStringTwo = "Car is blue and old"; 
    string[] subs = baseStringOne.Split(' '); 
    foreach (string sub in subs)
    {
      if (baseStringTwo.Contains(sub))
      {
         //Substring found!
      }
    }
