        [STAThread]
        static void Main(string[] args)
        {
            string fileNameToProcess = @"D:\Book2.xlsx";
            //Start Excel and create a new document.
            xls.Application oExcel = new xls.Application();
            xls.Workbook wb = null;
            try
            {
                wb = oExcel.Workbooks.Open(
                    fileNameToProcess.ToString(), false, false, Type.Missing, "", "", true, xls.XlPlatform.xlWindows, "", false, false, 0, false, true, 0);
                //wb.RefreshAll();
                xls.Sheets sheets = wb.Worksheets as xls.Sheets;
                xls.Worksheet sheet = sheets[1];
                //Following is used to find range with data
                string startRange = "A1";
                string endRange = "P25";
                xls.Range range = sheet.get_Range(startRange, endRange);
                range.CopyPicture(xls.XlPictureAppearance.xlScreen, xls.XlCopyPictureFormat.xlBitmap);
                System.Drawing.Image imgRange = GetImageFromClipboard();
                imgRange.Save(@"d:\ExcelSheetImage.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                wb.Save();
                Console.Write("Specified range converted to image successfully. Press Enter to continue.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            finally 
            {
                wb.Close();
                oExcel.Quit();
                oExcel = null;
            }
            Console.ReadLine();
        }
        public static System.Drawing.Image GetImageFromClipboard()
        {
            System.Drawing.Image returnImage = null;
            
            // This doesn't work
            //if (Clipboard.ContainsImage())
            //{
            //    returnImage = Clipboard.GetImage();
            //}
            //return returnImage;
            // This works
            System.Windows.Forms.IDataObject d = Clipboard.GetDataObject();
            if (d.GetDataPresent(DataFormats.Bitmap))
            {
                returnImage = Clipboard.GetImage();
            }
            return returnImage;
        }
