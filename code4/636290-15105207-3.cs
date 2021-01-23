    //string[] exp = System.Text.RegularExpressions.Regex.Split(oldstr, "-");
    //use string split rathre than using regular expression because character split is 
    // faster than regular expression split
    string[] exp = oldstr.Split('-');
    if(exp.Length>0)
    {
      int int1;
      if(int.TryParse(exp[0], out num1))
     { // further code }
      int int2;
     if(int.TryParse(exp[1], out num1))
     { // further code }
    }
  
