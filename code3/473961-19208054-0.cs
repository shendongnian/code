            CRAXDRT.Report report1 = new CRAXDRT.Report();
            CRAXDRT.Application app1 = new CRAXDRT.Application();
            stdole.IFontDisp myFont;
            report1 = app1.OpenReport("Test.rpt", OpenReportMethod.OpenReportByDefault);
            foreach (CRAXDRT.Section sec in report1.Sections)
            {
                for (int i = 1; i < sec.ReportObjects.Count + 1; i++)
                {
                     object objMain, objChange;
                    objMain = report1.Sections[sec.Name].ReportObjects[i];
                    try
                    {
                        objChange = objMain;
                        CRAXDRT.TextObject to1 = (CRAXDRT.TextObject)objChange;
                        myFont = to1.Font;
                        myFont.Name = "Arial";
                        to1.Font = myFont;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            objChange = objMain;
                            CRAXDRT.FieldObject to1 = (CRAXDRT.FieldObject)objChange;
                            myFont = to1.Font;
                            myFont.Name = "Arial";
                            to1.Font = myFont;
                        }
                        catch (Exception){}
                    }
                }
            }
