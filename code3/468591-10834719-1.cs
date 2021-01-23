      /// <summary>
      /// Saves data to the Access database to the Excel file specified by the filename
      /// </summary>
      public void Save(string excelFile) {
        using (ExcelWriter writer = new ExcelWriter(excelFile)) {
          writer.WriteStartDocument();
          foreach (DataTable table in Dataset.Tables) {
            writer.WriteStartWorksheet(string.Format("{0}", SafeName(table.TableName))); // Write the worksheet contents
            writer.WriteStartRow(); //Write header row
            foreach (DataColumn col in table.Columns) {
              writer.WriteExcelUnstyledCell(col.Caption);
            }
            writer.WriteEndRow();
            foreach (DataRow row in table.Rows) { //write data
              writer.WriteStartRow();
              foreach (object o in row.ItemArray) {
                writer.WriteExcelAutoStyledCell(o);
              }
              writer.WriteEndRow();
            }
            writer.WriteEndWorksheet(); // Close up the document
          }
          writer.WriteEndDocument();
          writer.Close();
        }
      }
