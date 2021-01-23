        STP_FriendsHolder.Dispatcher.BeginInvoke(AddRosterItem);
 
        void AddRosterItem()
        {
            RosterItemControl rosterItem = new RosterItemControl();
            rosterItem.RosterItemName = item.Jid.User;
            rosterItem.Margin = new Thickness(0);
            STP_FriendsHolder.Children.Add(rosterItem);
        }
