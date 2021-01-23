    // Remove until count != 0 is found
    foreach (var item in StatusList.ToArray())
    {
        if (item.Count == 0)
            StatusList.Remove(item);
        else
            break;
    }
    // Reverse the list
    StatusList.Reverse(0, StatusList.Count);
    // Remove until count != 0 is found
    foreach (var item in StatusList.ToArray())
    {
        if (item.Count == 0)
            StatusList.Remove(item);
        else
            break;
    }
    // reverse back
    StatusList.Reverse(0, StatusList.Count);
