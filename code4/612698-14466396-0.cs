    Excel.Workbook Workbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            if (Workbook != null)
            {
                Office.Workbook vstoWorkbook = Globals.Factory.GetVstoObject(Workbook);
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveSheet;
                if (worksheet != null)
                {
                    Office.Worksheet vstoSheet = Globals.Factory.GetVstoObject(worksheet);
                    vstoSheet.PageSetup.CenterFooter = "testing the footer";
                }
            }
