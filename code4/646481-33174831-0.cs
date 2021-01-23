    /* Cause the original ListBoxItem to lose focus
        * only if another ListBoxItem is being selected.
        * If a different element type is selected, the
        * original ListBoxItem will keep focus.
        */
    private void CheckFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        // check if focus is moving from a ListBoxItem, to a ListBoxItem
        if (e.OldFocus.GetType().Name == "ListBoxItem" && e.NewFocus.GetType().Name == "ListBoxItem")
        {
            // if so, cause the original ListBoxItem to loose focus
            (e.OldFocus as ListBoxItem).IsSelected = false;
        }
    }
