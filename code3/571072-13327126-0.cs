    using (StreamReader reader = new StreamReader(responseData))
      {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                 string m = "<a href=\"(.*)\" class=\"name\">(.*)</a>";
                 Match match = Regex.Match(line, m, RegexOptions.IgnoreCase);
                 if (match.Success)
                 {
                     listBox1.Items.Add(match.Groups[2].Value.ToString());
                 }
             }
      }
