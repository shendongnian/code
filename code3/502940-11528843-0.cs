    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Bytescout.Spreadsheet;
    
    namespace Converting_XLS_to_TXT
    {
    class Program
    {
    static void Main(string[] args)
    {
    // Create new Spreadsheet from SimpleReport.xls file
    Spreadsheet document = new Spreadsheet("SimpleReport.xls");
    
    // delete output file if exists already
    if (File.Exists("SimpleReport.txt")){
    File.Delete("SimpleReport.txt");
    }
    
    // save into TXT
    document.Workbook.Worksheets[0].SaveAsTXT("SimpleReport.txt");
    
    }
    }
    }
