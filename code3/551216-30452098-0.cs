            bool more = true;
            ItemView view = new ItemView(int.MaxValue, 0, OffsetBasePoint.Beginning);
            view.PropertySet = PropertySet.IdOnly;
            FindItemsResults<Item> findResults;
            List<EmailMessage> emails = new List<EmailMessage>();
            while (more)
            {
                findResults = service.FindItems(WellKnownFolderName.Inbox, view);
                foreach (var item in findResults.Items)
                {
                    emails.Add((EmailMessage)item);
                }
                more = findResults.MoreAvailable;
                if (more)
                {
                    view.Offset += 1000;
                }
            }
