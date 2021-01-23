        private static void DataSetToExcel(DataSet dataSet, string filePath)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                foreach (DataTable dataTable in dataSet.Tables)
                {
                    ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add(dataTable.TableName);
                    workSheet.Cells["A1"].LoadFromDataTable(dataTable, true);
                }
                pck.SaveAs(new System.IO.FileInfo(filePath));
            }
        }
