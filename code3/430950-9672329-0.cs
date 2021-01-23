        static void ReadMSOffice2003ExcelFile(string file) {
            FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
            ReadMSOfficeExcelFile(file, ExcelReaderFactory.CreateBinaryReader(stream));
        }
        static void ReadMSOffice2007ExcelFile(string file) {
            FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
            ReadMSOfficeExcelFile(file, ExcelReaderFactory.CreateOpenXmlReader(stream));
        }
        static void ReadMSOfficeExcelFile(string file, IExcelDataReader xlsReader) {
            string xlsRow;
            while (xlsReader.Read()) {
                xlsRow = "";
                for (int i = 0; i < xlsReader.FieldCount; i++) {
                    xlsRow += " " + xlsReader.GetString(i);
                }
                CheckLineMatch(file, xlsRow);
            }
        }
