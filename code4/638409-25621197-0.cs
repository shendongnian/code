    public static bool TryParseSqlDateTime(string someval, DateTimeFormatInfo dateTimeFormats, out DateTime tryDate)
        {
            bool valid = false;
            tryDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            System.Data.SqlTypes.SqlDateTime sdt;
            if (DateTime.TryParse(someval, dateTimeFormats, DateTimeStyles.None, out tryDate))
            {
                try
                {
                    sdt = new System.Data.SqlTypes.SqlDateTime(tryDate);
                    valid = true;
                }
                catch (System.Data.SqlTypes.SqlTypeException ex)
                {
                   
                }
            }
            return valid;
        }
