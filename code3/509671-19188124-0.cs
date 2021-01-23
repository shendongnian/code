        private bool IsValidDateFormat(string dateFormat)
        {
            try
            {
                String dts=DateTime.Now.ToString(dateFormat);
                DateTime.ParseExact(dts, dateFormat, CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
