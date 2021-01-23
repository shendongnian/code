    for (int i = 0; i < playersOnlineList.Items.Count; i++)
    {
        if (((UserStatus)playersOnlineList.Items[i]).Username == x) {
            ((UserStatus)playersOnlineList.Items[i]).Status = newStatus;
            break;
        }
    }
