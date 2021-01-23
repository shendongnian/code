    public static string getcolours()
    {
        List<string> colours = new List<string>();
        DBClass db = new DBClass();
        DataTable allcolours = new DataTable();
        allcolours = db.GetTableSP("kt_getcolors");
        for (int i = 0; i < allcolours.Rows.Count; i++)
        {
            string s = allcolours.Rows[i].ItemArray[0].ToString();
            string missingpath = "images/color/" + s + ".jpg";
            if (!FileExists(missingpath))
            {
                colours.Add(s);
            }
        }
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"F:\test.txt", true))
        {
            foreach(string color in colours)
            {
                file.WriteLine(color);
            }
        }
        return string.Join("\n", colours);;
    } 
    
