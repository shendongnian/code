    var pushPins = SOs_Classes.SOs_Utils.FindVisualChildren<Pushpin>(bingMap);
    foreach (var pushPin in pushPins)
    {
        if (pushPin.Tag is SOs_Locations)
        {
            SOs_Locations locs = (SOs_Locations) pushPin.Tag;
            if (locs.GroupName == groupToAddOrRemove)
            {
                bingMap.Children.Remove(pushPin);
            }
        }
    }
