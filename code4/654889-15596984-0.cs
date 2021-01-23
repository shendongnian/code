    // your line 
    string[] values = line.Split(',');
    // my addition
    for(int pair=0; pair<values.Length; pair=pair+2)
    {
       string iValue = values[pair];
       string vValue = values[pair+1];
       
       Double i;
       Double v;
       bool iOk = Double.TryParse(iValue, out i);
       bool vOk = Double.TryParse(vValue, out v);
       if (iOk && vOk)
       {
           Double r = i/v;
           Console.WriteLine("{0} (R) = {1} (I) / {2} V ",r, i, v);
       }
       else
       {
           Console.WriteLine("{0} or {1} is not parseable", iValue, vValue);
       }
    }
