    public void myMethod()
    {
        List<string[]> list = new List<string[]>();
        for (int i = 0; i < myGrid.Rows.Count; i++)
        {
            string[] linie = new string[3];
            linie[0] = myGrid.Rows[i].Cells[1].Value.ToString();
            linie[1] = myGrid.Rows[i].Cells[3].Value.ToString();
            linie[2] = myGrid.Rows[i].Cells[2].Value.ToString();
            {
                list.Add(linie);
            }
        }
        string path = "S:\\file.txt";
        StreamWriter file = new System.IO.StreamWriter(path);
        foreach (string[] x in list)
        {
            string s = string.Join(",", x);
            file.WriteLine(s);
        }
            file.Close();
    } 
