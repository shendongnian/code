    public xxxx sss(List s,var i)
    {
      try
    {
    var result = s.ElementAt(i);
    s.Remove(result);
    }
    catch(Exception e)
    {
    Console.WriteLine(e.message);
    }
    }
