    private List<XmlInfo> Grid_Values()
    {
        List<XmlInfo> CellValues = new List<XmlInfo>();
    
        for (int i = 0; i < ToolMapGrid.Rows.Count; i++)
        {
            for (int j = 0; j < ToolMapGrid.ColumnCount; j++)
            {
                XmlInfo nfo = new XmlInfo { 
                    value = ToolMapGrid.Rows[i].Cells[j].Value.ToString(), 
                    row = i,
                    column = j}
                CellValues.Add(nfo);
           }
        }
    }
