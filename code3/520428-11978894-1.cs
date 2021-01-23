            Dictionary<DateTime, double> FlowInformation = new Dictionary<DateTime, double>();
            double initialialrec;
            string flow;
            foreach (KeyValuePair<DateTime, double> Entry in FlowInformation)
            {
                if (initialialrec != 0)
                {
                    if (Entry.Value > initialialrec)
                        flow = Entry.Key.ToShortDateString() + " " + Entry.Key.ToShortTimeString() + "+";
                    if (Entry.Value < initialialrec)
                        flow = Entry.Key.ToShortDateString() + " " + Entry.Key.ToShortTimeString() + "-";
                    initialialrec = Entry.Value;
                    file.WriteLine(flow);
                }
            }
