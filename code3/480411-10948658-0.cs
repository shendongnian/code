        int lineLength = 150;
        private string stringSplitter(string inString)
        {
            StringBuilder sb = new StringBuilder();
            while (inString.Length > 0)
            {
                if (inString.Length > lineLength)
                {
                    sb.AppendLine(inString.Substring(0, lineLength));
                    inString = inString.Substring(lineLength);
                }
                else
                {
                    sb.AppendLine(inString);
                    inString = "";
                }
            }
            return sb.ToString();
        }
