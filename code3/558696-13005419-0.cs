    public class CustomStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int? result;
            if (AnyParamIsNull(x, y, out result))
            {
                return result.Value;
            }
            string x1, y1;
            double x2, y2;
            SplitInput(x, out x1, out x2);
            SplitInput(y, out y1, out y2);
            if (x1.Length == y1.Length)
            {
                result = string.Compare(x1, y1);
                if (result.Value == 0)
                {
                    if (x2 < y2)
                    {
                        return -1;
                    }
                    else if (x2 > y2)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return result.Value;
                }
            }
            else
            {
                //To make AA before Z when desending
                return x1.Length - y1.Length;
            }
  
        }
        private bool SplitInput(string input, out string alphabets, out double number)
        {
            Regex regex = new Regex(@"\d*[.]?\d+");
            Match match = regex.Match(input);
            if (match.Success)
            {
                number = double.Parse(match.Value, CultureInfo.InvariantCulture);
                alphabets = input.Replace(match.Value, "");
                return true;
            }
            else
            {
                throw new ArgumentException("Input string is not of correct format", input);
            }
        }
        private bool AnyParamIsNull(string x, string y, out int? result)
        {
            result = null;
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're 
                    // equal.  
                    result = 0;
                    return true;
                }
                else
                {
                    // If x is null and y is not null, y 
                    // is greater.  
                    result = -1;
                    return true;
                }
            }
            else
            {
                // If x is not null... 
                // 
                if (y == null)
                // ...and y is null, x is greater.
                {
                    result = 1;
                    return true;
                }
            }
            return false;
        }
    }
