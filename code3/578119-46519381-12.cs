    static void ProcessLargeFile()
    {
            if (File.Exists(outFileName)) File.Delete(outFileName);
    
            string text = File.ReadAllText(inputFileName, Encoding.UTF8);
    
            // EX 1 This opens entire file in memory and uses Replace and Regex Replace --> might cause out of memory error
    
            text = text.Replace("</text>", "");
    
            text = Regex.Replace(text, @"\<ref.*?\</ref\>", "");
    
            File.WriteAllText(outFileName, text);
    
	
            // EX 2 This reads file line by line 
            if (File.Exists(outFileName)) File.Delete(outFileName);
			
            using (var sw = new StreamWriter(outFileName))      
            using (var fs = File.OpenRead(inFileName))
            using (var sr = new StreamReader(fs, Encoding.UTF8)) //use UTF8 encoding or whatever encoding your file uses
            {
                string line, newLine;
    
                while ((line = sr.ReadLine()) != null)
                {
                  //note: call your own replace function or use String.Replace here 
                  newLine = Util.ReplaceDoubleBrackets(line);
 
                  sw.WriteLine(newLine);
                }
            }
        }
    
        public static string ReplaceDoubleBrackets(string str)
        {
            //note: this replaces the first occurrence of a word delimited by [[ ]]
            //replace [[ with your own delimiter
            if (str.IndexOf("[[") < 0)
                return str;
    
            StringBuilder sb = new StringBuilder();
    
            //this part gets the string to replace, put this in a loop if more than one occurrence  per line.
            int posStart = str.IndexOf("[[");
            int posEnd = str.IndexOf("]]");
            int length = posEnd - posStart;
            // ... code to replace with newstr
           
            sb.Append(newstr);
    
            return sb.ToString();
        }
