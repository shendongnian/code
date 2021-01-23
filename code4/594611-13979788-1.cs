    // Add "using DataLib;" and
    // "using Microsoft.Office.Interop.Excel;" to namespace declaration
    public void useExcel(Worksheet sh) // Worksheet is Excel Interop object
    {
        Class1 one = new Class1();
        one.Readsheet(sh);
    }
