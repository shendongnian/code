       //This would convert the listview1 content to Excel document and create the file in the given path        
        private void CreateExcelFromListview()
        {
            ListViewExport.ListViewToCsv(listView1, "C:\\test.csv", true);
            OpenInExcel("C:\\test.csv");
        }
    
        //This would open the document on screen
        public void OpenInExcel(string strFileName)
        {
            try
            {
                new Excel.Application {Visible = true}.Workbooks.Open(strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
