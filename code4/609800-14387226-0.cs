    int i = 0;
    while ( i <= 10 )
    {
      Console.WriteLine(i.ToString());
      if ( i == 8 )
      {
        // Do some work here, then bail on this iteration.
        goto Continue;
      }
    
    Continue:  // Yes, C# does support labels, using sparingly!
      i++;
    }
