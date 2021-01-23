    public static int StringToInt(this string number)
            {
                try
                {
                    int result;
                    if (!Int32.TryParse(number, out result))
                    {
                        // handle the parse failure
                    }
                    return result;
                }
            }
