            EventFeed calFeed = service.Query(query) as EventFeed;
            while (calFeed != null && calFeed.Entries.Count > 0)
            {
                foreach (EventEntry entry in calFeed.Entries)
                {
                    DateTime modified = entry.Edited.DateValue;
                }
            }
