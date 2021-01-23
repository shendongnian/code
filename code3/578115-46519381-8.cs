    static void ProcessLargeFile()
    {
            if (File.Exists(outFileName)) File.Delete(outFileName);
    
            string text = File.ReadAllText(inputFileName, Encoding.UTF8);
    
            // PROC 1 This opens entire file in memory and uses Replace and Regex Replace --> might cause out of memory error
    
            text = text.Replace("</text>", "");
    
            text = Regex.Replace(text, @"\<ref.*?\</ref\>", "");
    
            File.WriteAllText(outFileName, text);
    
	
            // PROC 2 This reads file line by line and uses String.IndexOf and String.Substring and StringBuilder to build the new lines 
            if (File.Exists(outFileName)) File.Delete(outFileName);
			
            using (var sw = new StreamWriter(outFileName))      
            using (var fs = File.OpenRead(inFileName))
            using (var sr = new StreamReader(fs, Encoding.UTF8)) //use UTF8 encoding or whatever encoding your file uses
            {
                string line, newLine;
    
                while ((line = sr.ReadLine()) != null)
                {
                    newLine = Util.ReplaceDoubleBrackets(line);
    
                   //note: don't use File.AppendAllText, it opens the file every time and could take forever to run. Instead use StreamWriter 
                   sw.Write(newLine + Environment.NewLine);
                }
            }
        }
    
        public static string ReplaceDoubleBrackets(string str)
        {
            //replace [[ with your own delimiter
            if (str.IndexOf("[[") < 0)
                return str;
    
            StringBuilder sb = new StringBuilder();
    
            //didn't test, but this part gets the string to replace, you might want to put this in a loop if more than one string can be found per line
            int posStart = str.IndexOf("[[");
            int posEnd = str.IndexOf("]]");
            int length = posEnd - posStart;
            //... replace String and then append it to StringBuilder
            sb.Append(newstr);
    
            return sb.ToString();
        }
