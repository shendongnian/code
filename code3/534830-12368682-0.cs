    foreach(var s in string_arr)
    {
      int index = 0;
     for(int i=0; i<s.Length;i++)
     {
        if(Char.IsDigit(s[i]))
        {
           index = i ;
        }
     }
       dictionary.Add(s.Substring(0,index), int.Parse(s.Substring(index));
    }
