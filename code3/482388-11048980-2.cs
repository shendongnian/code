    public bool? ShowConfirmationDialogs(IEnumerable<ItemType> items)
    {
        bool canContinue = true;
        foreach (var item in items)
        {
            Dialog dialog = new Dialog();
            dialog.Prepare(item);   // Prepares a "dialog" specific to each item
            bool? result = Service.ShowDialog(dialog);
            canContinue = result.HasValue && result.Value;
            if (!canContinue)
                break;
        }
        if (!canContinue)
        {
            // do something that changes current object's state
        }
        return canContinue;
    }
