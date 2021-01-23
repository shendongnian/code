        private bool ValidateCheckDigit()
        {
            
            Int32 _num = 0;
            Int32 _checkdigit = 0;
            for (int i = 0; i < CurrentUpcInfo.UpcCode.Length; i++)
            {
                if (i % 2 == 0)
                {
                    _num += (3 * Convert.ToInt32(CurrentUpcInfo.UpcCode.Substring(i, 1)));
                }
                else
                {
                    _num += Convert.ToInt32(CurrentUpcInfo.UpcCode.Substring(i, 1));
                }
            }
            _num = Math.Abs(_num) + 10;  // in case num is a zero
            _checkdigit = (10 - (_num % 10)) % 10;
            if (Convert.ToInt32(CurrentUpcInfo.Checkdigit) == _checkdigit)
                return true;
            return false;
        }
