    var items = theGUIManager.theDevice.channelCollection;
    // If you need to know if for all items IsAutoUpdated = true
    bool allChecked = items.All(item => item.IsAutoUpdated);
    // If you need to know if they're all false
    bool noneChecked = !items.Any(item => item.IsAutoUpdated);
