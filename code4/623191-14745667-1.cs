    var lastNameToFind = dgRow.Cells[2].Text.Replace("&amp;", "");
    var matched = dt.AsEnumerable()
                    .Where(dr => dr["LastName"].Equals(lastNameToFind))
                    .Any();
    if (matched)
    {
        DataRow newRow = dt.NewRow();
        dt.Rows.Add(newRow);
        newRow["FirstName"] = dgRow.Cells[1].Text;
        newRow["LastName"] = dgRow.Cells[2].Text;
        dt.AcceptChanges();
    }
