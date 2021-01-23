        string CleanXml(string DirtyXml)
        {
            //string clean = ""; 
            int startloc = 0, endloc = 0;
            for (int x = 0; x <= DirtyXml.Length-1; x++)
            {
                if (DirtyXml[x] == '<')
                {
                    startloc = x;
                    x++;
                }
                if (DirtyXml[x] == '>')
                {
                    endloc = x;
                    x++;
                    DirtyXml = DirtyXml.Remove(startloc, (endloc - startloc)+1);
                    x = 0;
                }   
            }
            return DirtyXml;
        }
