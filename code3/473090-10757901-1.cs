        public bool CheckConsistancy(List<string> fileLines)
        {
            bool status = false;
            if (fileLines != null && fileLines.Count > 0)
            {
                if(fileLines.Count % 4 == 0)
                {
                    List<List<string>> fileLineGroups = fileLines.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / 4).Select(x => x.Select(v => v.Value).ToList()).ToList();
                    foreach (List<string> fileLineGroup in fileLineGroups)
                    {
                        if (checkLine(@"^#\d", fileLineGroup[0])) 
                        {
                            if (checkLine(@"^DIRECTION: (REVERSE|FORWARD)", fileLineGroup[1]))
                            {
                                if (checkLine(@"^SPEED: \d", fileLineGroup[2]))
                                {
                                    if (checkLine(@"^(TIME|ROTATIONS): \d", fileLineGroup[3]))
                                    {
                                        status = true;
                                    }
                                    else
                                    {
                                        status = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    status = false;
                                    break;
                                }
                            }
                            else
                            {
                                status = false;
                                break;
                            }
                        }
                        else
                        {
                            status = false;
                            break;
                        }
                    }
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }
        private bool checkLine(string regExp, string line)
        {
            Regex r = new Regex(regExp);
            return r.IsMatch(line);
        } 
