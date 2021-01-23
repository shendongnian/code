    // Add "using Microsoft.Office.Interop.Excel;" 
    // and "using DataLib;" to namespace declarations
    public void useExcel(Worksheet sh) // Worksheet is Excel Interop object
    {
        Class1 one = new Class1();
        one.Readsheet(sh);
    }
