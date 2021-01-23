    private Worksheet _xlSheet;
    private static readonly int ITEMDESC_COL = 1;
    private static readonly int WIDTH_FOR_ITEM_DESC_COL = 42;
    . . .
    _xlSheet.Columns.AutoFit();
    // Now take back the wider-than-the-ocean column
    ((Range)_xlSheet.Cells[ITEMDESC_COL, ITEMDESC_COL]).EntireColumn.ColumnWidth =  WIDTH_FOR_ITEM_DESC_COL;
