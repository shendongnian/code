    public static void ReplaceInvalidCharFromAttribute(string filePath, string startElement, string nextElement, string[] removeStrings)
            {
                string tempFile = Path.GetTempFileName();
    
                using (var sr = new StreamReader(filePath))
                {
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;
                        string temp;
                        while ((line = sr.ReadLine()) != null)
                        {
                            temp = RemoveInvalidCharFromAttribute(line, startElement, nextElement, removeStrings);
                            sw.WriteLine(temp??line);
                        }
                    }
                }
    
                File.Delete(filePath);
                File.Move(tempFile, filePath);
            }
    public static string RemoveInvalidCharFromAttribute(string input, string startElement, string nextElement, string[] invalidChars)
            {
                if (input.IndexOf(startElement) < 0 || input.IndexOf(nextElement) < 0) return null;
                int start =input.IndexOf(startElement) + startElement.Length;
                int end = input.IndexOf(nextElement);
                StringBuilder res = new StringBuilder(input.Substring(start, (end - start)));
                StringBuilder resCopy = new StringBuilder(res.ToString());
    
                foreach (string inv in invalidChars)
                    res.Replace(inv, "");
    
                // return the result after surrounding the text with double 
                return
                    input.Replace(
                    resCopy.ToString(),
                    (String.Concat("\"", String.Concat(res.ToString().Trim(), "\" "))));
            }
