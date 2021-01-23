    long innertime = 0;
    while (count <= TestCollection.Count) 
    {     
        innertime -= Stopw2.GetTimestamp();
        Medthod1();
        innertime += Stopw2.GetTimestamp();
        count++; 
    } 
    Console.WriteLine("{0} ms", innertime * 1000.0 / Stopw2.Frequency);
