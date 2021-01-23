     public static string SplitToLines(string text,char[] splitanyOf, int maxStringLength)
        {               
            var sb = new System.Text.StringBuilder();
            var index = 0;
            var loop = 0;
            while (text.Length > index)
            {
                // start a new line, unless we've just started
                if (loop != 0)
                {
                    sb.AppendLine();
                }
                // get the next substring, else the rest of the string if remainder is shorter than `maxStringLength`
                var splitAt = 0;
                if (index + maxStringLength <= text.Length)
                {
                    splitAt = text.Substring(index, maxStringLength).LastIndexOfAny(splitanyOf);
                }
                else
                {
                    splitAt = text.Length - index;
                }
                
                // if can't find split location, take `maxStringLength` characters
                if (splitAt == -1 || splitAt == 0)
                {
                    splitAt = text.IndexOfAny(splitanyOf, maxStringLength);
                }
           
                // add result to collection & increment index
                sb.Append(text.Substring(index, splitAt).Trim());
                if(text.Length > splitAt)
                {
                    text = text.Substring(splitAt + 1).Trim();
                }
                else
                {
                    text = string.Empty;
                }
                loop = loop + 1;
            }
            return sb.ToString();
        }
