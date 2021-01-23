    static void ProcessLargeFile()
        {
            if (File.Exists(temp1FileName)) File.Delete(temp1FileName);
            if (File.Exists(temp2FileName)) File.Delete(temp2FileName);
    
            string text = File.ReadAllText(inputFileName, Encoding.UTF8);
    
            // PROC 1 This opens entire file in memory and uses Replace and Regex Replace --> might cause out of memory error
    
            text = text.Replace("</text>", "");
    
            text = Regex.Replace(text, @"\<ref.*?\</ref\>", "");
    
            File.WriteAllText(temp1FileName, text);
    
            // PROC 2 This reads file line by line and uses String.IndexOf and String.Substring and StringBuilder to build the new lines 
    
            using (var sw = new StreamWriter(temp2FileName))      
            using (var fs = File.OpenRead(temp1FileName))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line, newdef;
    
                while ((line = sr.ReadLine()) != null)
                {
                    newdef = Util.ReplaceDoubleBrackets(line);
    
                   //note: don't use File.AppendAllText, it opens the file every time and could take forever to run. Instead use StreamWriter 
                   sw.Write(newdef  + Environment.NewLine);
                }
            }
        }
    
        public static string ReplaceDoubleBrackets(string def)
        {
            //replace [[ with your target tag
            if (def.IndexOf("[[") < 0)
                return def;
    
            StringBuilder sb = new StringBuilder();
            //... Some processing
    
            //didn't test, but this part gets the string to replace, you might want to put this in a loop if more than one string can be found per line
            int posStart = def.IndexOf("[[");
            int posEnd = def.IndexOf("]]");
            int length = posEnd - posStart;
            sb.Append(def.Substring(pos, length));
    
            //... Some processing
            return sb.ToString();
        }
