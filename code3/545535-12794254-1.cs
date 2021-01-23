          Workbook book = ****xyz****;
                if (book.HasPassword)
                {
                    book.Password = Properties.Settings.Default.ExcelFilePW;
                    MessageBox.Show("Excel file is encrpyted");
                }
