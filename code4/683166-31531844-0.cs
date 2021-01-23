        public string GetLine(string multiline,int line)
        {
            List<string> lines = new List<string>();
            lines = multiline.Split('\n').ToList<string>();
            
            return lines.Count >= line ? lines[line] : "";
        }
