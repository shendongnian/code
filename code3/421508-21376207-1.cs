    int CountDigitsAfterDecimal(double value)
            {
                bool start = false;
                int count = 0;
                foreach (var s in value.ToString())
                {
                    if (s == '.')
                    {
                        start = true;
                    }
                    else if (start)
                    {
                        count++;
                    }
                }
    
                return count;
            }
