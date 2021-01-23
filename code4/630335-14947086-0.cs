        // check if string is empty
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            
            if (input.Contains('_'))
            {
                return input.Replace('_', ' ');
            }
            else
            {
                StringBuilder newString = new StringBuilder();
                foreach (Char char1 in input)
                {
                    if (char.IsUpper(char1))
                        newString.Append(new char[] { ' ', char1 });
                    else
                        newString.Append(char1);
                }
                 
                newString.Remove(0, 1);
                return newString.ToString();
            }
