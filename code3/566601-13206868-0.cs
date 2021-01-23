    List<tableClass> list = MyCheckedList();
    for (int count = 0; count < checkedListBox1.Items.Count; count++)
    {
      if (list.Contains(checkedListBox1.Items[count].ToString()))
      {
        checkedListBox1.SetItemChecked(count, true);
      }
    }
