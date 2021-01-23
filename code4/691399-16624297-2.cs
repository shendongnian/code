    using xl = Microsoft.Office.Interop.Excel;
    ...
    public void DoStuff () {
        ...
        xl.Sheets sheets = book.Sheets;
        bool sheetsReleased = false;
        try {
            ...
            foreach (xl.Sheet in sheets) { ... try, catch and dispose of sheet ... }
            ... release sheets using Marshal.ReleaseComObject ...
            sheetsDisposed  = true;
        }
        catch (blah) { ... if !sheetsDisposed , dispose of sheets ... }
    }
