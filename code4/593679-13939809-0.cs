    foreach (Node node in nodes)
    {
        bool n;
        try
        {
            if (node == null) 
            {
               n = true; //do something to deal with a null node
            }
            else 
            {
              n = node.previous == null;
            }
        }
        catch (Exception e)
        {
            StreamWriter s = new StreamWriter("error.txt");
            s.WriteLine(e.Message);
            s.WriteLine("-----------");
            s.Close();
        }
    }
