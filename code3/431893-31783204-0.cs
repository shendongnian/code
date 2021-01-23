    string testList = "";
                String str1 = "";
                string logPath = @"E:\LogForConsoleApp.txt";
                string filePath = @"E:\SaveSheetName.txt";
                string Path = @"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\MSTest";
                List<string> ltSheetName = new List<string>();
                List<string> ltMethodName = new List<string>();
                Process myProcess = new Process();
                Excel.Application appExl = new Excel.Application();
                Excel.Workbook workbook = null;
                Excel.Worksheet NwSheet;
                Excel.Range ShtRange;
                appExl = new Excel.Application();
                workbook = appExl.Workbooks.Open("E:\\inputSheet3", Missing.Value, ReadOnly: false);
                NwSheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                ShtRange = NwSheet.UsedRange; //gives the used cells in sheet
                int rCnt = 0;
                int cCnt = 0;
    
                for (rCnt = 1; rCnt <= ShtRange.Rows.Count; rCnt++)
                {
                    for (cCnt = 1; cCnt <= ShtRange.Columns.Count; cCnt++)
                    {
                        if (Convert.ToString(NwSheet.Cells[rCnt, cCnt].Value2) == "Y")
                        {
                            ltSheetName.Add(NwSheet.Cells[rCnt, cCnt - 1].Value2);
                            //ltMethodName.Add(" /test:" + NwSheet.Cells[rCnt, cCnt - 1].Value2);
                        }
                    }
                }
                workbook.Close(false, Missing.Value, Missing.Value);
                appExl.Quit();
    
                for (int sht = 0; sht < ltSheetName.Count; sht++)
                {
                    ltMethodName.Clear();
                    appExl = new Excel.Application();
                    workbook = appExl.Workbooks.Open(ltSheetName[sht].ToString(), Missing.Value, ReadOnly: false);
                    NwSheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                    ShtRange = NwSheet.UsedRange; //gives the used cells in sheet
                    int rCnt1 = 0;
                    int cCnt1 = 0;
    
                    for (rCnt1 = 1; rCnt1 <= ShtRange.Rows.Count; rCnt1++)
                    {
                        for (cCnt1 = 1; cCnt1 <= ShtRange.Columns.Count; cCnt1++)
                        {
                            if (Convert.ToString(NwSheet.Cells[rCnt1, cCnt1].Value2) == "Y")
                            {
                                ltMethodName.Add(" /test:" + NwSheet.Cells[rCnt, cCnt - 1].Value2);
                            }
                        }
                    }
                    workbook.Close(false, Missing.Value, Missing.Value);
                    appExl.Quit();
    
    
                    for (int i = 0; i < ltMethodName.Count; i++)
                    {
                        str1 = ltMethodName[i].ToString();
                        testList += str1;
                    }
    
                    string foldername = "TestResult_" + DateTime.Today.ToString().Remove(DateTime.Today.ToString().LastIndexOf("/") + 5);
                    foldername = foldername.Replace("/", "");
    
                    string direc = @"E:\" + foldername;
                    string fileName = ltSheetName[sht].ToString().Substring(ltSheetName[sht].ToString().LastIndexOf("\\") + 1) + "_InderdeepAutRes.trx";
                    if (!Directory.Exists(direc))
                        Directory.CreateDirectory(direc);
                    string testcase = "";
    
                    if (!File.Exists(direc + "\\" + fileName))
                        testcase = " /testcontainer:" + "E:\\Practice\\TestingSample\\TestingSample\\bin\\Debug\\TestingSample.dll" + testList + " /resultsfile:" + direc + "\\" + fileName;
                    else
                    {
                        Directory.Delete(direc, true);
                        Directory.CreateDirectory(direc);
                        testcase = " /testcontainer:" + "E:\\Practice\\TestingSample\\TestingSample\\bin\\Debug\\TestingSample.dll" + testList + " /resultsfile:" + direc + "\\" + fileName;
                    }
    
                    ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(Path, testcase);
    
                    try
                    {
                        TextWriter tw = new StreamWriter(filePath, false);
                        tw.WriteLine(ltSheetName[sht].ToString());
                        tw.Close();
                        myProcess.StartInfo = myProcessStartInfo;
                        myProcessStartInfo.UseShellExecute = false;
                        myProcessStartInfo.RedirectStandardOutput = true;
                        myProcess.Start();
                        string output = myProcess.StandardOutput.ReadToEnd();
                        //myProcess.WaitForExit();
                        Console.WriteLine(output);
    
                    }
                    catch (Exception ex)
                    {
                        TextWriter tw = new StreamWriter(logPath, true);
                        tw.WriteLine(ex.StackTrace);
                        tw.Close();
                    }
                }
