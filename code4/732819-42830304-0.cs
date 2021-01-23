    //get current in useing excel
                Process[] excelProcsOld = Process.GetProcessesByName("EXCEL");
    			Excel.Application myExcelApp = null;
                Excel.Workbooks excelWorkbookTemplate = null;
                Excel.Workbook excelWorkbook = null;
    try{
    	//DO sth using myExcelApp , excelWorkbookTemplate, excelWorkbook
    }
    catch (Exception ex ){
    }
    finally
                {
                    //Compare the EXCEL ID and Kill it 
                    Process[] excelProcsNew = Process.GetProcessesByName("EXCEL");
                    foreach (Process procNew in excelProcsNew)
                    {
                        int exist = 0;
                        foreach (Process procOld in excelProcsOld)
                        {
                            if (procNew.Id == procOld.Id)
                            {
                                exist++;
                            }
                        }
                        if (exist == 0)
                        {
                            procNew.Kill();
                        }        
                    }
                }
