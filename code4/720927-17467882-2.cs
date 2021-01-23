        private void CreateXLS(string data)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\data.xls";
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            // List of lists containing each line split by part
            List<List<string>> dataList = new List<List<string>>();
            List<string> valuesA = new List<string>();
            // Building the list
            foreach (string line in data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                List<string> partsLine = new List<string>();
                partsLine.AddRange(line.Split('\t'));
                dataList.Add(partsLine);
            }
            int row = 1;
            int col = 1;
            foreach (List<string> list in dataList)
            {
                foreach (string str in list)
                {
                    xlWorkSheet.Cells[row, col] = str;
                    if (list.IndexOf(str) == list.Count - 1)
                        col = 1;
                    else
                        col++;
                }
                row++;
            }
            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            textBoxData.AppendText("\nData saved to .xls file (path : " + path + ")");
        }
