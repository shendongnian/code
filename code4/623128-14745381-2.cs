    private static void ProcessFile()
    {
        string lines;
        string[] ContentData;
        bool blnReadFile = true;
        while (blnReadFile)
        {
            lines = File.ReadLines("Data.csv");
            if (String.IsNullOrEmpty(content))
            {
                blnReadFile = false;
            }
            else
            {
                ContentData = ProcessRawNumbers(lines); /* Ihave retained your metod to get each line */
            }
        }
        DataTable dt = ArrayToDataTable(ContentData);
        dg.DataSource = dt; /* dg refers to Datagrid */
        dg.DataBind();
    }
    public DataTable ArrayToDataTable(string[] arr)
    {
        DataTable dt = new DataTable();
        string[] header = arr[0].Split(',');
        foreach (string head in header)
        {
            dt.Columns.Add(head);
        }
        for (int theRow = 0; theRow < arr.Length; theRow++)
        {
            if (theRow != 0)
            {
                string str = arr[theRow];
                string[] item = str.Split(',');
                DataRow dr = dt.NewRow();
                for (int theColumn = 0; theColumn < item.Length; theColumn++)
                {
                    dr[theColumn] = item[theColumn];
                }
                dt.Rows.Add(dr);
            }
        }
        return dt;
    }
