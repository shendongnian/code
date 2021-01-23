    foreach (Node node in nodes)
    {
        try
        {
            if(null == node) throw new Exception("This is not expected!");
            bool n = node.previous == null;
        }
        catch (Exception e)
            {
                StreamWriter s = new StreamWriter("error.txt");
                s.WriteLine(e.Message);
                s.WriteLine("-----------");
                s.Close();
            }
    }
