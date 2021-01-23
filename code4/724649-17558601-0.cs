    int priv = 0;
    var lines = File.ReadAllLines("H:\\sample file.txt").Select(s=>s.Trim());
    foreach (var line in lines)
    {
        if (line.Contains(";"))
        {
            DataRow[] result = table.Select(string.Format("iID={0}", priv));
            result[0]["Comment"] = line;
        }
        else
        {
            row = table.NewRow();
            row["iID"] = counter;
            counter++;
            priv = counter;
            var words = line
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(it => it.Trim());
            int columnCount = 0;
            foreach (var word in words)
            {
                columnCount++;
                row[columnCount] = word;
            }
            table.Rows.Add(row);
        }
    
        if (Math.Floor((double)counter / 5) != Math.Floor((double)(counter - 1) / 5))
        {
            bulkCopy.WriteToServer(table);// here i missing coment  ;chennai
            table.Clear();
        }
    
        cnt++;
    }
