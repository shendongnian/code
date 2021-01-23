        Table t = new Table();
        List<string> cells = new List<string>();
        foreach (TableRow r in t.Rows)
        {
            foreach (TableCell cell in r.Cells)
            {
                cells.Add(cell.ToString());
            }
        }
        String[] array = cells.ToArray();
