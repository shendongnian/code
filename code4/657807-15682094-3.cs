    bool isFirst = true;
    foreach (var item in temp3)
    {
        if (!isFirst || !string.IsNullOrEmpty(item))
        {
            // Process item.
        }
        isFirst = false;
    }
