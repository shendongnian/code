            string fmtLine = "";
            string[] splitedFmtLine;
            int counterFMTlines = 0;
            var messageTimes = new Dictionary<string, LinkedList<L3Message>>();
            foreach (L3Message message in rez)
            {
                LinkedList<L3Message> list=null;
                messageTimes.TryGetValue(message.Time, out list);
                list = list ?? new LinkedList<L3Message>();
                list.AddLast(message);
                messageTimes[message.Time] = list;
            }
            foreach (string fmtF in fmtFiles)
            {
                using (StreamReader sr = new StreamReader(fmtF))
                {
                    while ((fmtLine = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(counterFMTlines++);
                        splitedFmtLine = fmtLine.Split('\t');
                        LinkedList<L3Message> messageList = null;
                        messageTimes.TryGetValue(splitedFmtLine[0], out messageList);
                        if(messageList != null)
                        {
                            foreach (var message in messageList)
                            {
                                message.ScramblingCode = splitedFmtLine[7];                                
                            }
                        }
                    }
                }
            } 
