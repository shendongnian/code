    for (int i = 0; i < listView1.Items.Count; i++)
    {
       if( i < aa.Length)
       {
          string input = aa[i];
          int index = input.IndexOf("'");
          if (index > 0)
             input = input.Substring(0, index);
          listView1.Items[i].SubItems.Add(input);
       }
    }
