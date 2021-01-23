    bool passedFirst = false;
    foreach (var item in temp3)
    {
        Contract.Assume(item != null);
        if (passedFirst || item != "")
        {
            // Process item.
        }
        passedFirst = true;
    }
