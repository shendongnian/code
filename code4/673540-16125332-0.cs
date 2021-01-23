    String line = null;
    var input = new List<int>();
    while ((line = file.ReadLine()) != null)
    {
        int i = 0;
        if( int.TryParse(line,out i))
        {
           input.Add(i);
        }
    }
