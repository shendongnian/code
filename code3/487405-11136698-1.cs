    public int CreateMyTask()
    {
            try
            {
                Console.WriteLine("Invoking CreateTask method");
                Console.WriteLine("-----------------------------------");
                m_taskID = taskClient.CreateTask(m_tInstance);
                Console.WriteLine("Task create successfully:ID=" + m_taskID.ToString());
                Console.WriteLine("-----------------------------------");
                WriteResultInExcel(false, "");
                return m_taskID;
            }
            catch(Exception ex)
            {
                WriteResultInExcel(true, ex.Message);
            }
    }
     private void WriteResultInExcel(bool isExceptionalData, string message)
     {
            Excel.ApplicationClass excelApp = new ApplicationClass();
            Workbook workbook = excelApp.Workbooks.Open("D:\\excel.xls", 0, false, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Worksheet worksheet = (Worksheet)workbook.Sheets.get_Item(1);
            if(isExceptionalData)
            {
                ((Range)worksheet.Cells["2", "J"]).Value2 = "FAIL";
                ((Range)worksheet.Cells["2", "K"]).Value2 = message;
            }
            else
            {
                ((Range)worksheet.Cells["2", "J"]).Value2 = "PASS";
            }
            workbook.Save();
            workbook.Close(0, 0, 0);
            excelApp.Quit();
     }
