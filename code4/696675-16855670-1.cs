                    xlAppNew = new Application();
                    xlAppNew.DisplayAlerts = true;
                    workbooks = xlAppNew.Workbooks;
                    workbook = workbooks.Open(@filepathnew, 0, true, 1, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);                    
                    if (getExtension.ToLower() == ".xls")
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath_second + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";
                    else
                        connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath_second + ";Extended Properties=Excel 12.0 Xml;HDR=Yes;IMEX=1;";
                    OleDbConnection con = new OleDbConnection(connString);
                    con.Open();
                    System.Data.DataTable dtSheet = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string tname = dtSheet.Rows[0]["TABLE_NAME"].ToString();                    
                    OleDbDataAdapter ad = new OleDbDataAdapter(@"Select * FROM [" + tname + "];", con);
                    DataSet dset = new DataSet();
                    ad.Fill(dset);
                    range = xlWorkSheet.UsedRange;
                    range = range.get_Resize(range.Rows.Count, 9);
                    //Create an array.
                    string[,] saRet = new string[range.Rows.Count, 9];
                    //Fill the array.
                    for (int iRow = 0; iRow < range.Rows.Count - 1; iRow++)
                    {
                        for (int iCol = 0; iCol < 9; iCol++)
                        {
                            switch (iCol)
                            {
                                case 0:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(3, 9);//iRow.ToString() + "|" + iCol.ToString();
                                    break;
                                case 1:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(12, 4);
                                    break;
                                case 2:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(16, 18);
                                    break;
                                case 3:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(34, 8);
                                    break;
                                case 4:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(42, 4);
                                    break;
                                case 5:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(46, 18);
                                    break;
                                case 6:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(64, 40);
                                    break;
                                case 7:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(104, 3);
                                    break;
                                case 8:
                                    saRet[iRow, iCol] = dset.Tables[0].Rows[iRow][0].ToString().Substring(107, 5);
                                    break;
                            }
                        }
                    }
                    //Set the range value to the array.
                    range.set_Value(Missing.Value, saRet);
                    FieldInfo myf = typeof(MyNewService).GetField("saRet");//Fieldinfo object is also an important part
                    //**********************
                    ((Range)xlAppNew.Cells[1, 1]).EntireColumn.TextToColumns(Type.Missing, Microsoft.Office.Interop.Excel.XlTextParsingType.xlFixedWidth, Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierNone, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, myf, Type.Missing, Type.Missing, Type.Missing);
                    xlAppNew.ActiveWorkbook.SaveAs(@temp_path, -4143, "", "", false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing);
