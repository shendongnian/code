         List<string> results = new List<string>();
         MatchCollection mc = Regex.Matches("yourstring", "McReplay:(.+?)[0-9]{2}:[0-9]{2}:[0-9]{2}", RegexOptions.Singleline);
         foreach (Match item in mc)
         {
            results.Add(item.Result("$1"));
         }
