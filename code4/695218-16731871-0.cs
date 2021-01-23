    string[] lines = IO.File.ReadAllLines("FilePath")
    List<string> lst = new List<string>();
    List<string> lstgroup = new List<string>();
    
    int i=0;
    foreach(string line in lines)
    {
        if(line.Tolower().contains("this is common text"))
        {
             if(i > 0)
             {
                 lst.AddRange(lstgroup.ToArray());
                 
                 // Print elements here
                 lstgroup.Clear();
             }
             else { i++; }
             continue;
        }
        else
        {
          lstgroup.Add(line)
        }
    }
    i = 0;
    // Print elements here too
