    var list = new List<string>();
    for (int i = 1; i <= 36; i++)
    {
        var result = string.Empty; 
        if(i < 10)
        {
             result = string.Format("0{0}", i);
        }
        else
        {
            result = i.ToString();
        }
        list.Add(result);
    }
