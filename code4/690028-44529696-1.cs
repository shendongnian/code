    public void FillForm()
    //Function reads entries from an Excel spreadsheet then uses values to populate and fill the form
    {
    
        string xlString;
        int xlRowCnt = 0;
        int xlColCnt = 0;
    
        var xlApp = new Application();
        //Open Excel file
        var xlWorkBook = xlApp.Workbooks.Open(@"MSI_Data_file.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        var xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                
        //This gives the used cells in the sheet
    
        var xlrange = xlWorkSheet.UsedRange;
    
        // XPath formatters for each 
        Func<string,string> inputName = (id) => String.Format("//input[contains(@name, '{0}')]", id);
        Func<string, string> inputId = (id) => String.Format("//input[@id='{0}']", id);
        Func <string, string> selectId = (id) => String.Format("//select[@id= '{0}']", id);
        Func<string, string> selectName = (id) => String.Format("//select[contains(@name, '{0}')]", id);
        Func<string, string> textareaName = (id) => String.Format("//textarea[contains(@name, '{0}')]", id);
    
        // map a fieldname to an Xpath formatter
        // Order of the fields is important!
        var fields = new List<string> {
            inputName("FirmName"),
            inputName("FirstName"),
            inputName("LastName"),
            inputName("Email"),
            inputName("FirmAddress"),
            selectId("ddlCountry"),
            inputName("PhoneNumber"),
            inputName("FaxNumber"),
            inputName("Website"),
            textareaName("Comments"),
            inputId("chkFirm_Service_Accounting"),
            selectName("LeadSource"),
        };
        // handle all rows
        for (xlRowCnt = 1; xlRowCnt <= xlrange.Rows.Count; xlRowCnt++)
        {
            // handle each column, based on the column number
            for (xlColCnt = 1; xlColCnt <= xlrange.Columns.Count; xlColCnt++)
            {
                var value = xlrange.Cells[xlRowCnt, xlColCnt].Value2;
                // if value contains a double or a date, this will still work
                xlString = (value ?? "").ToString();
    
                // this will give you the correct XPath
                var xpath = fields[xlColCnt -1]; 
                // find 
                driver.FindElement(By.XPath(xpath)).SendKeys(xlString);
            }
    
            //save screenshot of completed form
            SaveScreenShot("CompleteForm");
            driver.FindElement(By.XPath("//a[contains(text(), 'Submit')]")).Click();
            //Take screenshot of successful form submission
            SaveScreenShot("Submission_Success");
            driver.FindElement(By.XPath("//a[contains(text(), 'click here')]")).Click();
        }
    }
