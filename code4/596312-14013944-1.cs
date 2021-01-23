            string LoadedFile = File.ReadAllText("1.txt");
            string result = String.Empty;
            MatchCollection mc = Regex.Matches(LoadedFile, "(Dialogue.+?$)", RegexOptions.Multiline);
            foreach (Match m in mc)
            {
                result += m.Result("$1");
            }
