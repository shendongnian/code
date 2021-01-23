          List<string> categories = new List<sting>();
          categories.Add("Cat 1");
          categories.Add("Cat 2");
          categories.Add("Cat 3");
          int index;
    
          //Instead of traversing checkedListBox1 I have traversed List
          foreach (string str in list)
          {
           index = checkedListBox1.Items.IndexOf(str);
           if (index < 0) continue;
           if (str == checkedListBox1.Items[index].ToString())
            {
             checkedListBox1.SetItemChecked(index, true);
            }
          }
