    for (int i = 0; i < playersOnlineList.Items.Count; i++) {
        var userStatus = (UserStatus)playersOnlineList.Items[i];
        if (userStatus.Username == x) {
            userStatus.Status = newStatus;
            break;
        }
    }
