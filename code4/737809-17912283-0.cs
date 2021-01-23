    try
    {
       byte b = 100;
       b = checked((byte)(b + 200));
       Console.WriteLine("VALUE OF BYTE TYPE'S OBJECT {0}", b);
    }
    catch(OverFlowException e)
    {
       Console.WriteLine(e.Message);
    }
