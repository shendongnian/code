    string formatProofCellReading(ICell cell)
    {
        if (cell == null)
        {
            return "";
        }
        if (cell.CellType == CellType.NUMERIC)
        {
            double d = cell.NumericCellValue;
            return (d.ToString());
        }
        return cell.ToString();
    }
