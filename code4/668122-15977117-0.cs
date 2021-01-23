    var property = HWRes.HWResObj.GetType().GetProperty(MyGlobals.ListOfItemsToControl[i].sItemName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    if (property != null)
    {
        string HWTemp = property.GetValue(HWRes.HWResObj, null).ToString();
    }
    else
    {
        // property does not exist
    }
