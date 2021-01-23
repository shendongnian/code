        int index = await TaskEx.Run(() =>
                {
                    // ensure that sResults is a List<T> - call .ToList() if necessary
                    for (int i = 0; i < sResults.Count; i++)
                    {
                        if (sResults[i].DisplayIndexForSearchListBox.Trim().Contains(ayaStr))
                        {
                            return i;
                        }
                    }
                    return -1; // nothing found
                });
        //await TaskEx.Delay(1000);
        if (index >= 0)
        {
            stkPanelGoto.Visibility = Visibility.Collapsed;
            lstGoto.SelectedIndex = i;
            lstGoto_SelectionChanged(lstReadingSearchResults, null);
        }
        else //the index didn't match
        {
            MessagePrompt.ShowMessage("The test'" + ayaStr + "' does not exist.", "Warning!");
        }
