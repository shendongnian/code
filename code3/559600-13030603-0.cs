    bool allFieldsOne = false;
    table.Rows.Add("0", "0", "0", "0", "0");
    while (!allFieldsOne)
    {
        DataRow lastRow = table.Rows[table.Rows.Count - 1];
        DataRow currentRow = table.Rows.Add();
        currentRow[4] = "0";
        for (int f = 3; f >= 0; f--)
        {
            if (lastRow.Field<string>(f) == "0")
            {
                currentRow[f] = "1";
                while (--f >= 0)
                    currentRow[f] = "0";
                break;
            }
            else
            {
                currentRow[f] = "1";
                allFieldsOne = f == 0;
            }
        }
    }
