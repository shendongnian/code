    foreach (string d in Directory.GetDirectories(path))
    {
        try
        {
            foreach (string f in Directory.GetFiles(path))
            {
                //do something
            }
            //do something
        }
        catch(Excepion)
        {
           // If there is an error in the foreach, log error and...
                continue;
        }
    }
