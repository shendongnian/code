    static Excel.Application OpenExcel(){
        try{
            Excel.Application excel = new Excel.Application();
            return excel;
        }
        catch(Exception ex){
            log(ex.Message);
            return null;
        }
        finally{
            Marshal.FinalReleaseComObject(excel);
            excel = null;
        }
    }
    static void ParseFile(string file)
    {
        try
        {
            System.Console.WriteLine("parsing:" + file);            
            Excel.Workbook wb = excel.Workbooks.Open(file);
            Excel.Worksheet ws = wb.Worksheets[1];
            for (int i = 2; i < 27; i++)
            {
                log(ws.Cells[i, 1].Text);
            }
            wb.Close(false);    
        }
        catch (Exception ex)
        {
            log(ex.Message);
        }
        finally{
            Marshal.FinalReleaseComObject(ws);
            Marshal.FinalReleaseComObject(wb);
            ws = null;
            wb = null;
        }
    }
    static void CloseExcel(Excel.Application excel){
        try{
            excel.Quit();
        }
        catch(Exception ex){
            log(ex.Message);
        }
        finally{
            Marshal.FinalReleaseComObject(excel);
            excel = null;
        }
    }
