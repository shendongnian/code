    string text = stringWithNewLines;
    text = text.Replace(Environment.NewLine,"\n");
    string[] lines = text.Split(new Char[] { '\n' });
    for (int x = 0; x < lines.Length; x++)
    {  
        if (lines[x] != "")
        {
        dt.Rows.Add(lines[x]); //Add each string to datatable rows for use in datagrid
        }
     }
