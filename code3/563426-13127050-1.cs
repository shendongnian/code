    string[] readText = File.ReadAllLines("myfile.txt");
    int i = 0;
    foreach (string s in readText)
    {
        string[] currentline = s.Split('*');
    
        if (currentline[0] == "OTI")
        {
            lbRecon.Items.Add(readText[i+2].Substring(8, 9));
        }
    i++;
    }
