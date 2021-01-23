        public static bool IsMyStringValid(string strValidateString)
        {
            bool boolIsValid = false;
            if (strValidateString.All(Char.IsDigit))
            {
                boolIsValid = true; 
            }
            return boolIsValid; 
        }
