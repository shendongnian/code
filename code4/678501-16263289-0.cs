    while (ObjReader.Read())
    {
         VolT0 = ObjReader.GetValue(0).ToString(); //time column value
         VolK0 = ObjReader.GetValue(1).ToString(); //strike column value
         VolK1 = ObjReader.GetValue(2).ToString(); //vol column value
    
         Console.WriteLine("time = {0}, strike = {1}, vol = {2}", VolT0 , VolK0, VolK1 );
    }
