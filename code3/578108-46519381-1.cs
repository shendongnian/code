        static void ProcessLargeFile()
        {
            
            if (File.Exists(outputDefsFileName)) File.Delete(outputDefsFileName);
            if (File.Exists(defTempProc1FileName)) File.Delete(defTempProc1FileName);
            if (File.Exists(defTempProc2FileName)) File.Delete(defTempProc2FileName);
            string text = File.ReadAllText(inputDefsFileName, Encoding.UTF8);
            // PROC 1 This opens entire file in memory and uses Replace and Regex Replace
            text = text.Replace("</text>", "");
            text = Regex.Replace(text, @"\<ref.*?\</ref\>", "");
            File.WriteAllText(defTempProc1FileName, text);
            // PROC 2 This reads file line by line and uses String.IndexOf and String.Substring and StringBuilder to build the new lines 
 
            using (var fileStream = File.OpenRead(defTempProc1FileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line, newdef;
                
                while ((line = streamReader.ReadLine()) != null)
                {
                    
                    String[] arr = line.Split('\t');
                    string def = arr[2];
                    newdef = Util.ProcessDoubleBrackets(def);
                    File.AppendAllText(defTempProc2FileName, newdef  + Environment.NewLine);
                }
            }
        }
	    public static string ProcessDoubleBrackets(string def)
        {
            if (def.IndexOf("[[") < 0)
                return def;
            StringBuilder sb = new StringBuilder();
            ... Some processing
            sb.Append(def.Substring(pos, i - pos));
            ... Some processing
            return sb.ToString();
        }
