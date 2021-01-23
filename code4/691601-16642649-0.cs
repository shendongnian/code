     string ToLatinDigits(string nativeDigits)
        {
            int n = nativeDigits.Length;
            StringBuilder latinDigits = new StringBuilder(capacity: n);
            for (int i = 0; i < n; ++i)
            {
                if (char.IsDigit(nativeDigits, i))
                {
                    latinDigits.Append(char.GetNumericValue(nativeDigits, i));
                }
                else if (nativeDigits[i].Equals('.') || nativeDigits[i].Equals('+') || nativeDigits[i].Equals('-'))
                {
                    latinDigits.Append(nativeDigits[i]);
                }
                else
                {
                    throw new Exception("Invalid Argument");
                }
            }
            return latinDigits.ToString();
        }
