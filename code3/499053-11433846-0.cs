    NotificationWindowItem item = itemList.SingleOrDefault(elm => elm.UID == UID);
    if (item == null)
    {
        // ... some alternative or error handling code
    }
    else
    {
        item.Read = true;
    }
