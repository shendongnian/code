        public void PrintPreviewSSRSReport(string reportName)
        {
            try
            {
                string reportPath = string.Empty;
                string historyID = null;
                string deviceInfo = null;
                string extension = null;
                string encoding = null;
                string mimeType = null;
                string[] streamIDs = null;
                string format = "PDF";
                Byte[] result;
                MHTools.ReportExecution2005.Warning[] warnings = null;
                ExecutionInfo execInfo = new ExecutionInfo();
                TrustedUserHeader trusteduserHeader = new TrustedUserHeader();
                ExecutionHeader execHeader = new ExecutionHeader();
                ServerInfoHeader serviceInfo = new ServerInfoHeader();
                MHTools.ReportExecution2005.ReportParameter[] _parameters = null;
                ParameterValue[] _ParameterValue = null;
                //Set the report path
                reportPath = "/Reports/SalesReport";
                //Create the object of report execution web service
                ReportExecutionServiceSoapClient rsExec = new ReportExecutionServiceSoapClient();
                //Use this if you don't need to pass the credentials from code
                rsExec.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                //Load the reports 
                rsExec.LoadReport(trusteduserHeader, reportPath, historyID, out serviceInfo, out execInfo);
                execHeader.ExecutionID = execInfo.ExecutionID;
                //Get the parameters details from load report and eet the value in paremeters if any
                _parameters = execInfo.Parameters;
                _ParameterValue = new ParameterValue[1];
                _ParameterValue[0] = new ParameterValue();
                _ParameterValue[0].Name = _parameters[0].Name;
                _ParameterValue[0].Value = "12345";
                //Set the parameters
                rsExec.SetExecutionParameters(execHeader, null, _ParameterValue, "en-us", out execInfo);
                //Render the report
                rsExec.Render(execHeader, null, format, deviceInfo, out result, out extension, out mimeType, out encoding, out warnings, out streamIDs);
                //pass the file path where pdf file will be saved
                using (FileStream stream = File.OpenWrite(PDFFile))
                {
                    stream.Write(result, 0, result.Length);
                }
                //send the padf file path to printer
                SendFileToPrinter(PDFFile);
            }
            catch (Exception ex)
            {
                //
            }
        }
		
		
		#region Print SSRS Report
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);
        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);
        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int size);
        /// <summary>
        /// This function gets the pdf file name.
        /// This function opens the pdf file, gets all its bytes & send them to print.
        /// </summary>
        /// <param name="szPrinterName">Printer Name</param>
        /// <param name="szFileName">Pdf File Name</param>
        /// <returns>true on success, false on failure</returns>
        public bool SendFileToPrinter(string pdfFileName)
        {
            try
            {
                #region Get Connected Printer Name
                PrintDocument pd = new PrintDocument();
                StringBuilder dp = new StringBuilder(256);
                int size = dp.Capacity;
                if (GetDefaultPrinter(dp, ref size))
                {
                    pd.PrinterSettings.PrinterName = dp.ToString().Trim();
                }
                #endregion Get Connected Printer Name
                // Open the PDF file.
                FileStream fs = new FileStream(pdfFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = new Byte[fs.Length];
                bool success = false;
                // Unmanaged pointer.
                IntPtr ptrUnmanagedBytes = new IntPtr(0);
                int nLength = Convert.ToInt32(fs.Length);
                // Read contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                ptrUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, ptrUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                success = SendBytesToPrinter(pd.PrinterSettings.PrinterName, ptrUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(ptrUnmanagedBytes);
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// This function gets the printer name and an unmanaged array of bytes, the function sends those bytes to the print queue.
        /// </summary>
        /// <param name="szPrinterName">Printer Name</param>
        /// <param name="pBytes">No. of bytes in the pdf file</param>
        /// <param name="dwCount">Word count</param>
        /// <returns>True on success, false on failure</returns>
        private bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            try
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool success = false; // Assume failure unless you specifically succeed.
                di.pDocName = Path.GetFileNameWithoutExtension(PDFFile);
                di.pDataType = "RAW";
                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write the bytes.
                            success = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If print did not succeed, GetLastError may give more information about the failure.
                if (success == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
