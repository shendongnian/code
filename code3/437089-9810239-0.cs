    List<CellAlignment> cellAlignments = new List<CellAlignment>();
    foreach( int i in iCellAlignments)
    {
        cellAlignments.Add((CellAlignment)Enum.Parse(typeof(CellAlignment), i.ToString());
    }
