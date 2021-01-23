    public static int GetNoOfPagesPDF(string FileName)
        {
            int result = 0;
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            StreamReader r = new StreamReader(fs);
            string pdfText = r.ReadToEnd();
 
            System.Text.RegularExpressions.Regex regx = new Regex(@"/Type\s*/Page[^s]");
            System.Text.RegularExpressions.MatchCollection matches = regx.Matches(pdfText);
            result = matches.Count;
            return result;
 
        }
