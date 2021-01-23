    string val = "1567438absdg345";
    
    System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[1-9][0-9]*");
    
    string valNum = reg.Match(val).Value;
