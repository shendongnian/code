    using System; 
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text; 
    using Spire.Xls; 
     
    namespace ConvertExcelToPdf 
    { 
        class Program 
        { 
            static void Main(string[] args) 
            { 
               
                Workbook workbook = new Workbook(); 
                workbook.LoadFromFile(@"..\..\sample2.xlsx"); 
                workbook.ConverterSetting.SheetFitToPage = true; 
                workbook.SaveToFile(@"..\..\sample.pdf", FileFormat.PDF); 
                System.Diagnostics.Process.Start(@"..\..\sample.pdf"); 
            } 
        } 
    } 
