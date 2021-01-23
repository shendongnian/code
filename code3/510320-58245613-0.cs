        private void Button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = "ImageToExcel.xlsx";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Image to Excel";
                    string imageNetworkLocation = "\\\\192.168.240.110\\images\\image.png";
                    worksheet.Shapes.AddPicture(imageNetworkLocation, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 170, 85);
                    workbook.SaveAs(saveDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    application.Quit();
                    workbook = null;
                    application = null;
                }
            }
            else
                try
                {
                    workbook.Close(0);
                    application.Quit();
                    workbook = null;
                    application = null;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
                }
                catch (System.Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
