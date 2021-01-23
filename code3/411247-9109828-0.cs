        private void SetItemChecked(string item)
        {
            int index = GetItemIndex(item);
            if (index < 0) return;
            myCheckedListBox.SetItemChecked(index, true);
        }
        private int GetItemIndex(string item)
        {
            int index = 0;
            foreach (object o in myCheckedListBox.Items)
            {
                if (item == o.ToString())
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
