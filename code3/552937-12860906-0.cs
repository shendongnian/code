    List<String> list = new List<String>();
    
    list.Add("goal0=1234.4334abc12423423");
    list.Add("goal1=-23423");
    list.Add("asdfsdf");
    
    Regex regex = new Regex(@"^goal\d+=(?<GoalNumber>-?\d+\.?\d+)");
    
    foreach (string s in list)
    {
        if(regex.IsMatch(s))
        {
            string numberPart = regex.Match(s).Groups["GoalNumber"];
            
            // do something with numberPart
        }
    }
