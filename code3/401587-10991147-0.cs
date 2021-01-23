        private void button1_Click(object sender, EventArgs e)
        {
            //Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            
            //Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            
            //Open the excel file and instantiate the workbook object
            IWorkbook workbook = application.Workbooks.Open(@"..\..\Data\Book1.xlsx");
            //Retrieve the Excel comboBox from the worksheet
            IComboBoxShape xlComboBox = workbook.Worksheets[0].ComboBoxes[0];
            //user defined method to retrieve Excel ComboBox items and populate them in a Windows forms - ComboBox control
            RetrieveItemsFromExcelComboBox(xlComboBox, comboBox1);
            xlComboBox = workbook.Worksheets[0].ComboBoxes[1];
            RetrieveItemsFromExcelComboBox(xlComboBox, comboBox2);
            //Close the workbook.
            workbook.Close();
            //Dispose the excel engine
            excelEngine.Dispose();
        }
        /// <summary>
        /// Retrieve the items from the Excel ComboBox and populate them in Windows form - ComboBox control
        /// </summary>
        /// <param name="xlComboBox">Excel combobox instance (IComboBoxShape)</param>
        /// <param name="comboBox">Windows Forms - Combo Box instance</param>
        private void RetrieveItemsFromExcelComboBox(IComboBoxShape xlComboBox, ComboBox wfComboBox)
        {
            //Get the range where the ComboBox items are present in the workbook
            IRange xlRange = xlComboBox.ListFillRange;
            //iterate through the range of the comboBox items and add them into the Windows forms - ComboBox control
            for (int rowIndex = xlRange.Row; rowIndex <= xlRange.LastRow; rowIndex++)
            {
                for (int colIndex = xlRange.Column; colIndex <= xlRange.LastColumn; colIndex++)
                {
                    wfComboBox.Items.Add(xlRange[rowIndex, colIndex].DisplayText);
                }
            }
            wfComboBox.SelectedIndex = xlComboBox.SelectedIndex - 1;
        }
