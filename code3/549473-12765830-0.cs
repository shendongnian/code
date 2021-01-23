    foreach (string d in Directory.GetDirectories(path))
        {
            foreach (string f in Directory.GetFiles(path))
            {
            try
            {
                //do some thing
            }
            catch
            {
               // If there is an error on the foreach, I want it to keep on going to search another one
            }
            }
            //do some thing
        }
