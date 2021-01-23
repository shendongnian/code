        using (StreamReader Output = ExecuteTfsCommand(GetTfsHistoryCommand(fullFilePath)))
            {
                string line;
                bool foundChangeSetLine = false;
                Int64 latestChangeSet;
                while ((line = Output.ReadLine()) != null)
                {
                    if (foundChangeSetLine)
                    {
                        if (Int64.TryParse(line.Split(' ').First().ToString(), out latestChangeSet))
                        {
                            return latestChangeSet;   // this is the lastest changeset number of input file
                        }
                    }
                    if (line.Contains("-----"))       // output stream contains history records after "------" row
                        foundChangeSetLine = true;
                }
            }
