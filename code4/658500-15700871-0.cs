    if(str.Length>0 && ((str[0]=="J") || (str[0]=="C")))
    {
       columnsC = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
       if((str[0]=="J")
       {
                cbay.AC = columnsC[1];
                cbay.AU = columnsC[2];
                cbay.SA = columnsC[3];
                cbay.ABS = columnsC[5];
       }
       else
       {
                cbay.AU = columnsC[1];
                cbay.SA = columnsC[2];
       }
    }
