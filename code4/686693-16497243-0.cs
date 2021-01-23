            List<Template> matches = new List<Template>();
            List<Template> unmatches = new List<Template>();
            foreach (var entry in listForTemplate)
            {
                bool matched = false;
                foreach (var t1Entry in listForTemplate1)
                {
                    if (entry.ID == t1Entry.ID)
                    {
                        matches.Add(entry);
                        matched = true;
                        break;
                    }
                }
                if (!matched)
                {
                    unmatches.Add(entry);
                }
            }
