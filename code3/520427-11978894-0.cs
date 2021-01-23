            foreach(KeyValuePair Entry in in FlowInformation)
            {
                if(initialialrec!=0)
                {
                if(Entry.Key>initialialrec)
                    flow=Entry.Key.ToShortDateString() + " " + Entry.Key.ToShortTimeString() + "+";
                if(Entry.Key<initialialrec)
                    flow=Entry.Key.ToShortDateString() + " " + Entry.Key.ToShortTimeString()+"-";
                initialialrec=Entry.Key;
                file.WriteLine(flow);
                }
            }
