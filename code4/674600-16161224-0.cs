    Add this to `OpenXMLOffice` class:
        public void XMLToExcel(string strXMLPath, string outputFileName, string sheetName)
        {
            string strPath = Path.GetDirectoryName(strXMLPath);
            DataSet dsXML = new DataSet();
            dsXML.ReadXml(strXMLPath);
            strPath = strPath + "\\" + outputFileName + ".xlsx";
            DataTable tblXML = dsXML.Tables[0];
            tblXML.TableName = sheetName;
            DataTableToFilePath(tblXML, strPath);
        }
    and call it like this:
        var objTest = new MSDN.Sample.XMLToExcel.OpenXMLOffice();
        objTest.XMLToExcel(textBox14.Text, "My Excel", "My Sheet");
