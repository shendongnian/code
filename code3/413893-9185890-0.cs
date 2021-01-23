      for (int i = 0; i < checkedListBox1.Items.Count; i++)
      {
        if ((string)checkedListBox1.Items[i] == value)
        {
          checkedListBox1.SetItemChecked(i, true);
        }
      }
