        STP_FriendsHolder.Dispatcher.BeginInvoke(new Action(delegate
        {
            RosterItemControl rosterItem = new RosterItemControl();
            rosterItem.RosterItemName = item.Jid.User;
            rosterItem.Margin = new Thickness(0);
            STP_FriendsHolder.Children.Add(rosterItem);
        }));
