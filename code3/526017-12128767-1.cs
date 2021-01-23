    public void UpdateCellProperty (int id, string colName,
                                    Action<CellAppearance> appearanceAction)
    {
        CellAppearance cell;
        
        CellLocation location = new CellLocation(id, colName);
        if (CellAppearances.ContainsKey(location))
        {
            cell = CellAppearances[location];
        }
        else
        {
            cell = new CellAppearance(_DefaultFont, _DefaultBackColor,
                                      _DefaultForeColor);
        }
        appearanceAction(CellAppearances[location]);
    }
    
    public void UpdateCellFont(int id, string colName, Font font)
    {
        UpdateCellProperty(id, colName, c => c.Font = font);
    }
    public void UpdateCellBackColor(int id, string colName, Color backColor)
    {
        UpdateCellProperty(id, colName, c => c.BackColor = backColor);
    }
    public void UpdateCellForeColor(int id, string colName, Color foreColor)
    {
        UpdateCellProperty(id, colName, c => c.ForeColor = foreColor);
    }
