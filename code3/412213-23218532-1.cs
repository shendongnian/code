    FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                using (StreamReader stream = new StreamReader(fs))
                {
                    string line;
                    int i = 0;
                    while (!stream.EndOfStream && (i++ >= 0))//for neglecting first 150 rows the condition will be (i++ <= 150) try this.I hope it helps.
                    {
                        line = stream.ReadLine();
                    }
                }
