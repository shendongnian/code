    private void CopyCellsToClipboard(GridRangeInfo range)
    {
    StringBuilder sb = new StringBuilder();
    
    for (int i = range.Top; i <= range.Bottom; i++)
    {
    for (int j = range.Left; j <= range.Right; j++)
    {
    if (! (this.gridControl1.Cols.Hidden[j]))
    {
    sb.Append(this.gridControl1[i, j].FormattedText);
    sb.Append("\t");
    }
    }
    sb.AppendLine(System.Environment.NewLine);
    }
    string str = sb.ToString().Replace(System.Environment.NewLine + System.Environment.NewLine, System.Environment.NewLine);
    DataObject db = new DataObject(DataFormats.UnicodeText, str);
    Clipboard.SetDataObject(db);
    }
