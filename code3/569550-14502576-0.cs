        using System.Runtime.InteropServices;
        using Microsoft.Office.Interop.Excel;
        /// <summary>
        /// Excel application
        /// </summary>
        private ApplicationClass m_xlApp = null;
        /// <summary>
        /// Reference to the workbook.
        /// </summary>
        private Workbook m_book = null;
        /// <summary>
        /// Reference to the worksheet.
        /// </summary>
        private Worksheet m_sheet = null;
        
        /// <summary>
        /// Close the workbook.
        /// </summary>
        public void Close()
        {
            if (m_book != null)
                m_book.Close(Missing.Value, Missing.Value, Missing.Value);
            if (m_xlApp != null)
            {
                m_xlApp.Workbooks.Close();
                m_xlApp.Quit();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            // Release the objects
            Marshal.FinalReleaseComObject(m_sheet);
            Marshal.FinalReleaseComObject(m_book);
            Marshal.FinalReleaseComObject(m_xlApp);
            m_sheet = null;
            m_book = null;
            m_xlApp = null;
        }
