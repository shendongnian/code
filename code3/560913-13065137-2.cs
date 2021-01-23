            using (StreamReader fin = new StreamReader("text.txt"))
            {
                string tmp = fin.ReadToEnd();
                var matches = Regex.Matches(tmp, "(CM_) ([^;]*);", RegexOptions.Singleline);
                for (int i = 0; i < matches.Count; i++)
                    if (matches[i].Groups.Count == 3)
                        Console.WriteLine((2*i+1).ToString() + ". " + matches[i].Groups[1].Value + "\r\n" + (2*(i+1)).ToString() + ". " + matches[i].Groups[2].Value);
            }
