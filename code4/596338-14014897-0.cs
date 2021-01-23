            string LoadedFile = File.ReadAllText(@"C:\Base_Model.txt");
            StringBuilder result = new StringBuilder();
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                Match ma = Regex.Match(LoadedFile, "Verdieping " + i.ToString() + ".+?'Max'.*?([0-9].+?)[]][)];", RegexOptions.Singleline);
                if(!ma.Success)
                {
                    break;
                }
                string a = ma.Result("$1");
                MatchCollection mc = Regex.Matches(a, "(\\d+?)\r\n", RegexOptions.Singleline);
                for (int j = 0; j < mc.Count; j++)
                {
                    result.AppendLine(String.Format("Verdieping_{0}[{1}] = {2}", i, j, mc[j].Result("$1")));
                }
                result.AppendLine(String.Empty);
            }
            File.WriteAllText(@"C:\New_Model.txt", result.ToString());
