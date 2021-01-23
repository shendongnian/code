            using (StreamReader fin = new StreamReader("text.txt"))
            {
                string tmp = fin.ReadToEnd();
                var matches = Regex.Matches(tmp, "(CM_) ([^;]*);", RegexOptions.Singleline);
                int index = 0;
                foreach (Match match in matches)
                    if (match.Groups.Count == 3)
                        Console.WriteLine((++index).ToString() + ". " + match.Groups[1].Value + "\r\n" + (++index).ToString() + ". " + match.Groups[2].Value);
            }
