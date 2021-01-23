    foreach (var i in valueArray)
    {
       if (i.ToString() == "\n")
       {
          sw.Write(sw.NewLine);
       }
       else
       {
          sw.Write(i.ToString() + ",");
       }
    }
