    if (TimeSpanElapsedToSendNotificationFor(thisItem)) {
        if (isWeekend()) {
            thisItem.LastUpdate.AddDays(2);
            persist(thisItem); // update the DB
            return;
        }
        // send notification here..
    }
