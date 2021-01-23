        private static int LineNumber = 0;
        private List<string> textLines = new List<string>();
        public string GetTextLine()
        {
            const string pathFile = @"C:\test\Q.txt";
            if (textLines.Count == 0)
            {
                textLines = File.ReadLines(pathFile).ToList();
            }
            if (LineNumber < (textLines.Count - 1))
            {
                return textLines[LineNumber++];
            }
            return textLines[LineNumber];
        }
