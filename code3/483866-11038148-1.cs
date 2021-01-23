    foreach (DataColumn dc in dt.Columns)
    {
        string cellValue = dr[dc].ToString();
        cellValue = Regex.Replace(cellValue, "\n", "<br /"); 
        if (cellValue != "X" | cellValue != null)
        {
            string index = "r" + row.ToString() + "c" + col.ToString();
            Literal cellTarget = (Literal)form1.FindControl(index);
            cellTarget.Text = cellValue; 
        }
        col++;
    }
