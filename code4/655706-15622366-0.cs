    if (row.Cells[2].Value != null)
    {
        try
        {
            result += Convert.ToDouble(row.Cells[2].Value);
        }
        catch { }
    }
