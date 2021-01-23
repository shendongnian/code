        public static bool IsDateValid(string datestr)
        {
            bool IsValid = false;
            if (datestr.Length == 6)
            {
                try
                {
                    new DateTime(Convert.ToInt16(datestr.Substring(0, 2)), Convert.ToInt16(datestr.Substring(2, 2)), Convert.ToInt16(datestr.Substring(4)));
                }
                catch (Exception)
                {
                    IsValid = false;
                }
            }
            else
            {
                IsValid = false;
            }
            return IsValid;
        }
