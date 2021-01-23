        private static string getString(string input, char controlChar='D')
        {
            string numbersOnly = input.Replace("" + controlChar, "");
        
            string[] bounds = numbersOnly.Split('-');
            if( bounds.Length == 1 )
            {
                 return "" + controlChar + bounds[0];
            }
            else if (bounds.Length == 2)
            {
                string str = "";
                for (int i = Int32.Parse(bounds[0]); i <= Int32.Parse(bounds[1]); i++)
                {
                    str += controlChar + "" + i + ",";
                }
                str = str.TrimEnd(',');
                return str;
            }
            else
            {
                return "Error";
            }
        }
