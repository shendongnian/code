    public static DataTable GetDataTabletFromCSVFile(HttpPostedFileBase file)
    {
        DataTable csvDataTable = new DataTable();
        // Read bytes from http input stream
        var csvBody = string.Empty;
        using (BinaryReader b = new BinaryReader(file.InputStream))
        {
            byte[] binData = b.ReadBytes(file.ContentLength);
            csvBody = Encoding.UTF8.GetString(binData);
        }
        var memoryStream = new MemoryStream();
        var streamWriter = new StreamWriter(memoryStream);
        streamWriter.Write(csvBody);
        streamWriter.Flush();
        memoryStream.Position = 0;
        using (TextFieldParser csvReader = new TextFieldParser(memoryStream))
        {
            csvReader.SetDelimiters(new string[] { "," });
            csvReader.HasFieldsEnclosedInQuotes = true;
            string[] colFields = csvReader.ReadFields();
            foreach (string column in colFields)
            {
                DataColumn datecolumn = new DataColumn(column);
                datecolumn.AllowDBNull = true;
                csvDataTable.Columns.Add(datecolumn);
            }
            while (!csvReader.EndOfData)
            {
                string[] fieldData = csvReader.ReadFields();
                //Making empty value as null
                for (int i = 0; i < fieldData.Length; i++)
                {
                    if (fieldData[i] == "")
                    {
                        fieldData[i] = null;
                    }
                }
                csvDataTable.Rows.Add(fieldData);
            }
        }
        return csvDataTable;
    }
