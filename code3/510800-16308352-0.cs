    public void ReCalcuateFormula(Cell cell)
    {
        if (cell.CellFormula != null)
            cell.CellFormula.CalculateCell = new BooleanValue(true);
    }
