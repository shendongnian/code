    public static void Normalize2(string aFilePathName, string aSheetName, int aColOffSet, string aPivotColName, string aValueColName)
        {
            LOG.DebugFormat("Normaling data in file: {0}", aFilePathName);
            LOG.DebugFormat("Sheet Name:{0} ColOffset:{1}", aSheetName, aColOffSet);
            Excel.Application vExcel = new Excel.Application();
            Excel.Workbook vWorkbook = null;
            Excel.Worksheet vWsOriginal = null;
            Excel.Worksheet vWsNormalized = null;
            try
            {
                vExcel.Visible = false;
                vWorkbook = vExcel.Workbooks.Open(aFilePathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                vWsOriginal = vWorkbook.Worksheets[aSheetName];
                //vWsOriginal.Name = string.Format("Original_{0}", aSheetName);
                string vNormalizedSheetName = string.Format("Normalized {0}", aSheetName);
                bool vNormalizedSheetExists = (vWorkbook.Sheets.Cast<object>()
                                                .Select(sheetValue => sheetValue as Excel.Worksheet))
                                                .Any(wbSheet => wbSheet != null && wbSheet.Name == vNormalizedSheetName);
                if (!vNormalizedSheetExists)
                {
                    vWsNormalized = vWorkbook.Worksheets.Add(vWsOriginal, Type.Missing, Type.Missing, Type.Missing);
                    vWsNormalized.Name = vNormalizedSheetName;
                }
                else
                {
                    vWsNormalized = vWorkbook.Worksheets[vNormalizedSheetName];
                }
                vWsNormalized.UsedRange.ClearContents();
                long vTotalColumns = 1;
                long vRowCounter = 1;
                Excel.Range vWsRange = vWsOriginal.Cells[vRowCounter, vTotalColumns];
                List<string> vHeaders = new List<string>();
                while (vWsRange.Value2 != null)
                {
                    vHeaders.Add(vWsRange.Value2.ToString());
                    vTotalColumns = vTotalColumns + 1;
                    vWsRange = vWsOriginal.Cells[vRowCounter, vTotalColumns];
                }
                
                // Insert the headers
                for (int vHeaderCol = 1; vHeaderCol < aColOffSet; vHeaderCol++)
                {
                    vWsNormalized.Cells[1, vHeaderCol].Value = vHeaders[vHeaderCol - 1];
                }
                vWsNormalized.Cells[1, aColOffSet].Value = aPivotColName;
                vWsNormalized.Cells[1, aColOffSet + 1].Value = aValueColName;
                long vNewRow = 2;
                long vValueColumns = vTotalColumns - aColOffSet;
                vRowCounter = 2;
                Excel.Range vHeaderData = vWsOriginal.Range[vWsOriginal.Cells[1, aColOffSet],
                                                            vWsOriginal.Cells[1, vTotalColumns - 1]];
                string[] vPivotValueNames = new string[vTotalColumns - aColOffSet];
                vHeaders.CopyTo(aColOffSet - 1, vPivotValueNames, 0, (int) (vTotalColumns - aColOffSet));
                while (((Excel.Range)vWsOriginal.Cells[vNewRow, 1]).Value2 != null)
                {
                    Excel.Range vStaticRowData = vWsOriginal.Range[vWsOriginal.Cells[vNewRow, 1],
                                                                       vWsOriginal.Cells[vNewRow, aColOffSet - 1]];
                    Excel.Range vDynamicRowData = vWsOriginal.Range[vWsOriginal.Cells[vNewRow, aColOffSet],
                                                                       vWsOriginal.Cells[vNewRow, vTotalColumns - 1]];
                    long vDestRowStart = vRowCounter;
                    long vDestRowEnd = (vRowCounter + vValueColumns) - 1;
                    Excel.Range vNormalizedStaticRowData = vWsNormalized.Range[vWsNormalized.Cells[vDestRowStart, 1],
                                                                        vWsNormalized.Cells[vDestRowEnd, aColOffSet - 1]];
                    Excel.Range vNormalizedPivotValueRowData = vWsNormalized.Range[vWsNormalized.Cells[vDestRowStart, aColOffSet],
                                                                        vWsNormalized.Cells[vDestRowEnd, aColOffSet]];
                    Excel.Range vNormalizedValueRowData = vWsNormalized.Range[vWsNormalized.Cells[vDestRowStart, aColOffSet + 1],
                                                                        vWsNormalized.Cells[vDestRowEnd, aColOffSet + 1]];
                    vNormalizedStaticRowData.Value = vStaticRowData.Value;
                    vNormalizedPivotValueRowData.Value = vExcel.WorksheetFunction.Transpose(vHeaderData.Value);
                    vNormalizedValueRowData.Value = vExcel.WorksheetFunction.Transpose(vDynamicRowData.Value);
                    vNewRow = vNewRow + 1;
                    vRowCounter = vRowCounter + vValueColumns;
                }
            }
            finally
            {
                vWorkbook.Close(Excel.XlSaveAction.xlSaveChanges, Type.Missing, Type.Missing);
                Marshal.FinalReleaseComObject(vWsNormalized);
                Marshal.FinalReleaseComObject(vWsOriginal);
                Marshal.FinalReleaseComObject(vWorkbook);
                vExcel.Quit();
                Marshal.FinalReleaseComObject(vExcel);
            }
        }
