      private string[] SplitFields(string csvValue)
      {
         //if there aren't quotes, use the faster function
         if (!csvValue.Contains('\"') && !csvValue.Contains('\''))
         {
            return csvValue.Trim(',').Split(',');
         }
         else
         {
            //there are quotes, use this built in text parser
            using(var csvParser = new Microsoft.VisualBasic.FileIO.TextFieldParser(new StringReader(csvValue.Trim(','))))
            {
               csvParser.Delimiters = new string[] { "," };
               csvParser.HasFieldsEnclosedInQuotes = true;
               return csvParser.ReadFields();
            }
         }
      }
