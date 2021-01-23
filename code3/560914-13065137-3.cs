        static void PRegex()
        {
            using (StreamReader fin = new StreamReader("text.txt"))
            {
                string tmp = fin.ReadToEnd();
                var matches = Regex.Matches(tmp, "(CM_) ([^;]*);", RegexOptions.Singleline);
                for (int i = 0; i < matches.Count; i++)
                    if (matches[i].Groups.Count == 3)
                        Console.WriteLine((2 * i + 1).ToString() + ". " + matches[i].Groups[1].Value + "\r\n" + (2 * (i + 1)).ToString() + ". " + matches[i].Groups[2].Value);
            }
            Console.ReadLine();
        }
        static void PLineByLine()
        {
            var cmBlocks = new List<string>();
            using (StreamReader fin = new StreamReader("text.txt"))
            {
                string line = string.Empty;
                string currentCMBlock = null;
                bool endOfBlock = true;
                while ((line = fin.ReadLine()) != null)
                {
                    bool endOfLine = false;
                    while (!endOfLine)
                    {
                        if (endOfBlock)
                        {
                            int startIndex = line.IndexOf("CM_ ");
                            if (startIndex == -1)
                            {
                                endOfLine = true;
                                continue;
                            }
                            line = line.Substring(startIndex + 4, line.Length - startIndex - 4);
                            endOfBlock = false;
                        }
                        if (!endOfBlock)
                        {
                            int startIndex = line.IndexOf(";");
                            if (startIndex == -1)
                            {
                                currentCMBlock += line + "\r\n";
                                endOfLine = true;
                                continue;
                            }
                            else
                            {
                                currentCMBlock += line.Substring(0, startIndex);
                                if (!string.IsNullOrEmpty(currentCMBlock))
                                {
                                    cmBlocks.Add("CM_ ");
                                    cmBlocks.Add(currentCMBlock);
                                }
                                currentCMBlock = null;
                                line = line.Substring(startIndex + 1, line.Length - startIndex - 1);
                                endOfBlock = true;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < cmBlocks.Count; i++)
                Console.WriteLine((i + 1) + ". " + cmBlocks[i]);
            Console.ReadLine();
        }
