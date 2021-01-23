    public IEnumerable<string> CheckedItems
    {
        get
        {
            //If the items aren't strings `Cast` them to the appropirate type and 
            //optionally use `Select` to convert them to what you want to expose publicly.
            return checkedListBox1.SelectedItems
                .OfType<string>();
        }
        set
        {
            var itemsToSelect = new HashSet<string>(value);
    
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetSelected(i,
                    itemsToSelect.Contains(checkedListBox1.Items[i]));
            }
        }
    }
