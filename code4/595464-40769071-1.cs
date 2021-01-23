    public static void ExportPackingReport_NPOI(string filepath, DataTable table)
            {
                IWorkbook xwb; // Workbook
                HSSFSheet sheet; // Sheet
                HSSFChart chart_0;// chart 1
                HSSFChart chart_1;// chart 2
                HSSFChart chart_2;// chart 3
                int rowIndex = 60; //First row of table with data
                int colIndex = 0;//First column of table with data
                int rows_count = table.Rows.Count; //Count of data in table
                try
                {
                    //Read file
                    using (FileStream rstr = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    {
                        xwb = new HSSFWorkbook(rstr);
                        sheet = (HSSFSheet)xwb.GetSheet(xwb.GetSheetAt(0).SheetName);
                        var charts = HSSFChart.GetSheetCharts(sheet);
                        chart_0 = charts[0]; 
                        chart_1 = charts[1]; 
                        chart_2 = charts[2]; 
                        //Write file
                        using (FileStream wstr = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite))
                        {
                            //Populating file with data from Datatable
                            SetRowData_NPOI(table, xwb, rowIndex, colIndex);
                            //Overriding data ranges of charts 
                            CellRangeAddressBase chart_range_G = new CellRangeAddress(rowIndex + 1, rowIndex + rows_count, 6, 6);
                            CellRangeAddressBase chart_range_H = new CellRangeAddress(rowIndex + 1, rowIndex + rows_count, 7, 7);
                            CellRangeAddressBase chart_range_I = new CellRangeAddress(rowIndex + 1, rowIndex + rows_count, 8, 8);
                            CellRangeAddressBase chart_range_J = new CellRangeAddress(rowIndex + 1, rowIndex + rows_count, 9, 9);
                            //Apply new ranges of charts 
                            chart_0.Series[0].SetValuesCellRange(chart_range_G);
                            chart_0.Series[1].SetValuesCellRange(chart_range_J);
    
                            chart_1.Series[0].SetValuesCellRange(chart_range_H);
                            chart_1.Series[1].SetValuesCellRange(chart_range_J);
    
                            chart_2.Series[0].SetValuesCellRange(chart_range_I);
                            chart_2.Series[1].SetValuesCellRange(chart_range_J);
    
                            xwb.Write(wstr);
                            wstr.Close();
    
                        }
                        rstr.Close();
                        xwb.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
