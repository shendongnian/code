        for (int i = 0; i < playersOnlineList.Items.Count; i++) {
            if (playersOnlineList.Items[i].Username == x) {
                Player p = playersOnlineList.Items[i];
                p.Status = newStatus;
                playersOnlineList.Items[i] = p;
            }
        }
