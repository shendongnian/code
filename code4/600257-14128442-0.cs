                _Application xlApp;
            Workbook xlTemplateWB;
            Workbook xlTempWB;
            object missing = System.Reflection.Missing.Value;
            xlApp = new ApplicationClass();
            xlApp.Visible = true;
            //Open Bench Sheet Template
            xlTemplateWB = xlApp.Workbooks.Open(Elmnt.getDBPath() + TEMPLATENAME, 0, true, 5, "", "",
                false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Save As a temporary workbook
            xlTemplateWB.SaveAs(XLTempDir + XLTempName);
            xlTemplateWB.Close(true, missing, missing);
            releaseObject(xlTemplateWB);
            //Open temporary workbook
            xlTempWB = xlApp.Workbooks.Open(XLTempDir + XLTempName, 0, false, 5, true, "", true,
                XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //Remove non-applicable worksheets
            for (int i = xlTempWB.Sheets.Count; i > 0; i--)
            {
                if (((Worksheet)xlTempWB.Sheets[i]).Name != bchSheet)
                {
                    xlApp.DisplayAlerts = false;
                    ((Worksheet)xlTempWB.Sheets[i]).Delete();
                    xlApp.DisplayAlerts = true;
                }
            }
            xlTempWB.Save();
            //Close Workbooks
            xlTempWB.Close(true, missing, missing);
            xlApp.Quit();
            //Release Objects
            releaseObject(xlTempWB);
            releaseObject(xlApp);
