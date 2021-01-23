    ------------------------------------------------------------
    var excelHelper = new ExcelHelper(bytes);
    bytes = excelHelper.RenameTabs("Program Overview", "Go Green Plan", "Milestones", "MAT and EOC", "Annual Financials", "Risk Log", "Risk & Opportunity Log", "RAIL", "Meeting Minutes");
 
    Response.BinaryWrite(bytes);
    Response.End();
    ------------------------------------------------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using NPOI.HSSF.UserModel;
 
    namespace Company.Project.Core.Tools
    {
        public class ExcelHelper
        {
            private byte[] _ExcelFile;
 
            public ExcelHelper(byte[] excelFile)
            {
                _ExcelFile = excelFile;
            }
 
            public byte[] RenameTabs(params string[] tabNames)
            {
                byte[] bytes = null;
 
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(_ExcelFile, 0, _ExcelFile.Length);
                    var workBook = new HSSFWorkbook(ms, true);
 
                    if (tabNames != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            for (int i = 0; i < tabNames.Length; i++)
                            {
                                workBook.SetSheetName(i, tabNames[i]);
                            }
                            workBook.Write(memoryStream);
                            bytes = memoryStream.ToArray();
                        }
                    }
                }
                _ExcelFile = bytes;
                return bytes;
            }
        }
