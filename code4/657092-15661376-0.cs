    void FormatTable(params Table[] tables)
    {
        foreach(var table in tables)
        {
            table.BorderWidth = 2;
            table.BorderColor = Color.GloriousPink;
        }
    }
