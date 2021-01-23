    for (int i = 0; i <= (checkedListBoxPlatypi.Items.Count - 1); i++)
    {
        if (checkedListBoxPlatypi.GetItemCheckState(i) == CheckState.Checked)
        {
            ReturnListPlatypi.Add(ParsePlatypusID(checkedListBoxPlatypi.Items[i].ToString()));
        }
    }
