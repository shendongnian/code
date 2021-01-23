    DateTime start= DateTime.Now;
    for(int i = 0; i < 10000; i++)
    {
     DateTime end = DateTime.Now;
     if( start.Second != end.Second )
     {
      start = end;
      label1.Text = i.ToString();
     }
    }
