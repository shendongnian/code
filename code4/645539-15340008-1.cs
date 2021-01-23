	namespace TestNamespace {
		using Excel=Microsoft.Office.Interop.Excel;
		public static class TestClass {
			static DataTable BuildTestDataTable() {
				var dt=new DataTable();
				dt.Columns.Add("Name", typeof(String));
				dt.Columns.Add("Age", typeof(int));
				dt.Columns.Add("Gender", typeof(String));
				dt.Columns.Add("Memo", typeof(String));
				dt.Rows.Add(new object[] { "Leon Scott Kennedy", 36, "M", "'=== 1 ===" });
				dt.Rows.Add(new object[] { "Ada Wong", 39, "F", "'=== 3 ===" });
				return dt;
			}
			public static void ExportToExcel(this DataTable dt, String fileName) {
				var xlApp=new Excel.ApplicationClass();
				var xlWorkBook=xlApp.Workbooks.Open(
					fileName,
					0,
					false, // for read/write
					5, "", "", true, Excel.XlPlatform.xlWindows,
					"\t", false, false, 0, true, 1, 0
					);
				var xlWorkSheet=(Excel.Worksheet)xlWorkBook.Worksheets[1];
				var NumColumns=dt.Columns.Count;
				var rowCount=dt.Rows.Count;
				try {
					foreach(DataRow dr in dt.Rows) {
						for(int i=1; i<NumColumns+1; i++) {
							xlWorkSheet.Cells[rowCount, i]=dr[i-1].ToString();
						}
						rowCount+=1;
					}
					xlWorkBook.Save();
				}
				catch(Exception) {
					throw;
				}
				finally {
					xlApp.Quit();
				}
			}
			public static void TestMethod() {
				TestClass.BuildTestDataTable().ExportToExcel(@"c:\ExistingFile.xlsx");
				// TestClass.BuildTestDataTable().ExportToExcel(@"c:\ExistingFile.xls");
			}
		}
	}
