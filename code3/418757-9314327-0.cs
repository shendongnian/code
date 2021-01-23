            using System.Text.RegularExpression;
            Regex reg = new Regex(@"([\d|\.]*)(\w*)");
            string value = "123.4L";
            MatchCollection matches = reg.Matches(value);
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    GroupCollection groups = match.Groups;
                    Console.WriteLine(groups[1].Value); // will be 123.4
                    Console.WriteLine(groups[2].Value); // will be L
                }
            }
  
