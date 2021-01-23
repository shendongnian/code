            string fmtLine = "";
            string[] splitedFmtLine;
            int counterFMTlines = 0;
            var messageTimes = new Dictionary<string, L3Message>();
            foreach (L3Message message in rez)
            {
                messageTimes.Add(message.Time, message);
            }
            foreach (string fmtF in fmtFiles)
            {
                using (StreamReader sr = new StreamReader(fmtF))
                {
                    while ((fmtLine = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(counterFMTlines++);
                        splitedFmtLine = Regex.Split(fmtLine, "\t");
                        L3Message message = null;
                        messageTimes.TryGetValue(splitedFmtLine[0], out message);
                        if (message!=null) message.ScramblingCode = splitedFmtLine[7];
                    }
                }
            } 
