        public DateTime? SetDateTimeValue(DataTable dataTableIn
          , int rowNumber, string fieldName)
        {
            DateTime? returnValue = new DateTime?();
            DateTime tempValue = new DateTime();
            try
            {
             string fieldValueAsString = dataTableIn.Rows[rowNumber][fieldName].ToString();
             result = DateTime.TryParse(fieldValueAsString, out tempValue);
             if (result)
                    returnValue = tempValue;
                }
            catch
            {
                returnValue = null;
            }
            return returnValue;
        }
