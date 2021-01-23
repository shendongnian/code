    public class ExcelWriter : IDisposable {
      private XmlWriter writer;
      private static readonly DateTime NODATE = new DateTime(1900, 1, 1);
      public enum CellStyle { General, Number, Currency, DateTime, ShortDate };
      public ExcelWriter(string outputFileName) {
        if (!String.IsNullOrEmpty(outputFileName)) {
          XmlWriterSettings settings = new XmlWriterSettings();
          settings.Indent = true;
          writer = XmlWriter.Create(outputFileName, settings);
        } else {
          throw new Exception("Output path not supplied.");
        }
      }
      public void Close() {
        if (writer != null) {
          writer.Close();
          writer = null;
        } else {
          throw new NotSupportedException("Already closed.");
        }
      }
      public static bool HasValue(object obj) {
        if (obj != null) {
          if (obj != DBNull.Value) {
            string txt = obj.ToString();
            return (0 < txt.Length);
          }
        }
        return false;
      }
      public void WriteStartDocument() {
        if (writer != null) {
          writer.WriteProcessingInstruction("mso-application", "progid=\"Excel.Sheet\"");
          writer.WriteStartElement("ss", "Workbook", "urn:schemas-microsoft-com:office:spreadsheet");
          WriteExcelStyles();
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      public void WriteEndDocument() {
        if (writer != null) {
          writer.WriteEndElement();
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      private void WriteExcelStyleElement(CellStyle style) {
        if (writer != null) {
          writer.WriteStartElement("Style", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteAttributeString("ID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
          writer.WriteEndElement();
        }
      }
      private void WriteExcelStyleElement(CellStyle style, string NumberFormat) {
        if (writer != null) {
          writer.WriteStartElement("Style", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteAttributeString("ID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
          writer.WriteStartElement("NumberFormat", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteAttributeString("Format", "urn:schemas-microsoft-com:office:spreadsheet", NumberFormat);
          writer.WriteEndElement();
          writer.WriteEndElement();
        }
      }
      private void WriteExcelStyles() {
        if (writer != null) {
          writer.WriteStartElement("Styles", "urn:schemas-microsoft-com:office:spreadsheet");
          WriteExcelStyleElement(CellStyle.General);
          WriteExcelStyleElement(CellStyle.Number, "General Number");
          WriteExcelStyleElement(CellStyle.DateTime, "General Date");
          WriteExcelStyleElement(CellStyle.Currency, "Currency");
          WriteExcelStyleElement(CellStyle.ShortDate, "Short Date");
          writer.WriteEndElement();
        }
      }
      public void WriteStartWorksheet(string name) {
        if (writer != null) {
          writer.WriteStartElement("Worksheet", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteAttributeString("Name", "urn:schemas-microsoft-com:office:spreadsheet", name);
          writer.WriteStartElement("Table", "urn:schemas-microsoft-com:office:spreadsheet");
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      public void WriteEndWorksheet() {
        if (writer != null) {
          writer.WriteEndElement();
          writer.WriteEndElement();
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      public void WriteExcelColumnDefinition(int columnWidth) {
        if (writer != null) {
          writer.WriteStartElement("Column", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteStartAttribute("Width", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteValue(columnWidth);
          writer.WriteEndAttribute();
          writer.WriteEndElement();
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      public void WriteExcelUnstyledCell(string value) {
        if (writer != null) {
          writer.WriteStartElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteStartElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");
          writer.WriteValue(value);
          writer.WriteEndElement();
          writer.WriteEndElement();
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      public void WriteStartRow() {
        if (writer != null) {
          writer.WriteStartElement("Row", "urn:schemas-microsoft-com:office:spreadsheet");
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      public void WriteEndRow() {
        if (writer != null) {
          writer.WriteEndElement();
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      public void WriteExcelStyledCell(object value, CellStyle style) {
        if (writer != null) {
          writer.WriteStartElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
          writer.WriteAttributeString("StyleID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
          writer.WriteStartElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
          switch (style) {
            case CellStyle.General:
              writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");
              if (!HasValue(value)) {
                value = String.Empty; // DBNull.Value causes issues in an Excel cell.
              }
              break;
            case CellStyle.Number:
            case CellStyle.Currency:
              writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "Number");
              if (!HasValue(value)) {
                value = 0;
              }
              break;
            case CellStyle.ShortDate:
            case CellStyle.DateTime:
              writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "DateTime");
              if (!HasValue(value)) {
                value = NODATE;
              }
              break;
          }
          writer.WriteValue(value);
          writer.WriteEndElement();
          writer.WriteEndElement();
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      public void WriteExcelAutoStyledCell(object value) {
        if (writer != null) { //write the <ss:Cell> and <ss:Data> tags for something
          if (value is Int16 || value is Int32 || value is Int64 || value is SByte ||
              value is UInt16 || value is UInt32 || value is UInt64 || value is Byte) {
            WriteExcelStyledCell(value, CellStyle.Number);
          } else if (value is Single || value is Double || value is Decimal) { //we'll assume it's a currency
            WriteExcelStyledCell(value, CellStyle.Currency);
          } else if (value is DateTime) { //check if there's no time information and use the appropriate style
            WriteExcelStyledCell(value, ((DateTime)value).TimeOfDay.CompareTo(new TimeSpan(0, 0, 0, 0, 0)) == 0 ? CellStyle.ShortDate : CellStyle.DateTime);
          } else {
            WriteExcelStyledCell(value, CellStyle.General);
          }
        } else {
          throw new NotSupportedException("Cannot write after closing.");
        }
      }
      #region IDisposable Members
      public void Dispose() {
        if (writer != null) {
          writer.Close();
          writer = null;
        }
      }
      #endregion
    }
