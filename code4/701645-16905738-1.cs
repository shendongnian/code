    set2.Clear();
    s1 = DateTime.Now;
    MyObject matchingElement;
    x = 0;
    
    foreach (MyObject elem in list2)
    set2.Add(elem);
    foreach (MyObject t1 in list1)
    {
    if (set2.Contains(t1))
    {
        matchingElement = null;
        foreach (MyObject t2 in list2)
        {
    	    if (t1.X == t2.X && t1.Y == t2.Y && t1.Z == t2.Z && t1.M == t2.M)
      	    {
    	        x++;
    	        matchingElement = t2;
    	        break;
    	    }
        }
        //Do Something on matchingElement if not null
    }
    }
    Console.WriteLine("set foreach with contains: " + (DateTime.Now - s1).TotalSeconds + "\t X: " + x);
