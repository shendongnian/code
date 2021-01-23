        string PathFix(string path)
        {
            List<string> _forbiddenChars = new List<string>();
            _forbiddenChars.Add("?");
            _forbiddenChars.Add("<");
            _forbiddenChars.Add(">");
            _forbiddenChars.Add(":");
            _forbiddenChars.Add("|");
            _forbiddenChars.Add("\\");
            _forbiddenChars.Add("/");
            _forbiddenChars.Add("*");
            //_forbiddenChars.Add("\""); Do not delete the double-quote character, so we could replace it with 2 quotes (before the return).
            for (int i = 0; i < _forbiddenChars.Count; i++)
            {
                path = path.Replace(_forbiddenChars[i], "");
            }
            path = path.Replace("\"", "''"); //Replacement here
            return path;
        }
