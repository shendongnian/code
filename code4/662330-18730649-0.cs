    public static DataTable CSVToDataTable(string path, string name)
    {
        return CSVToDataTable(Path.Combine(path, name));
    }
    public static DataTable CSVToDataTable(string path)
    {
        DataTable res = new DataTable();
        if (!File.Exists(path))
        {
            return res;
        }
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader re = new StreamReader(stream))
            {
                if (re.EndOfStream)
                    return res;
                string line = re.ReadLine();
                if (line.IsNullOrWhiteSpace())
                    return res;
                string[] headers = LineToArray(line);
                foreach (string header in headers)
                {
                    res.Columns.Add(header);
                }
                int i = 0;
                string[] cells = new string[0];
                DataRow row = null;
                while (!re.EndOfStream)
                {
                    line = re.ReadLine();
                    if (line.IsNullOrWhiteSpace())
                        continue;
                    cells = LineToArray(line);
                    row = res.NewRow();
                    for (i = 0; i < headers.Length && i < cells.Length; i += 1)
                    {
                        row[i] = cells[i];
                    }
                    res.Rows.Add(row);
                }
            }
        }
        return res;
    }
    private static string[] LineToArray(string line, char delimiter = ',')
    {
        if (line.Contains("\""))
        {
            List<string> l = new List<string>();
            bool inq = false;
            string cell = string.Empty;
            char lastCh = 'x';
            foreach (char ch in line)
            {
                if (ch == '"')
                {
                    if (cell.Length == 0)
                    {
                        inq = true;
                    }
                    else if (lastCh == '\\')
                    {
                        cell += ch;
                    }
                    else
                    {
                        inq = false;
                    }
                }
                else if (delimiter == ch)
                {
                    if (inq)
                    {
                        cell += ch;
                    }
                    else
                    {
                        l.Add(cell);
                        inq = false;
                        cell = string.Empty;
                    }
                }
                else
                {
                    cell += ch;
                }
                if (inq)
                    lastCh = ch;
                else
                    lastCh = 'x';
            }
            return l.ToArray();
        }
        else
        {
            return line.Split(new String[] { delimiter.ToString() }, StringSplitOptions.None);
        }
    }
    public void insert(string path, string name, string table, bool KeepNulls){
        DataTable data = CSVToDataTable(path, name);
        //do data manipulation here
        SqlCeBulkCopyOptions options = new SqlCeBulkCopyOptions();
        if (KeepNulls)
        {
            options = options |= SqlCeBulkCopyOptions.KeepNulls;
        }
        using (SqlCeBulkCopy bc = new SqlCeBulkCopy(Fastway_Remote_Agent.Properties.Settings.Default.DatabaseConnectionString, options))
        {
            bc.DestinationTableName = table;
            bc.WriteToServer(data);
        }
    }
