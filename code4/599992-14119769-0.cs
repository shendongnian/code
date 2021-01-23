    foreach(string path in files)
    {
        string[] lines = System.IO.File.ReadAllLines(@"[FILE_NAME_HERE]");
        for (int i=0; i < lines.Count(); i++)
                {
                    if(lines[i].ToLower().Contains("namespace"))
                    {
                        int j = i + 2;
                        if(lines[j].ToLower().Contains("public class"))
                        {
                           string lClassname = lines[j].Replace("public class","");
                           //Save the class name here
                           break;
                        }
                    }
                }
    }
