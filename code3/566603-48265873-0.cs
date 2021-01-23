    DataTable dt = MyCheckedList();
    foreach (DataRow dr in dt.Rows)
    {
          for (int i = 0; i < checkedListBox1.Items.Count; i++)
           {
              if (dr["valueMember"].ToString() == ((DataRowView)checkedListBox1.Items[i])[0].ToString())
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
           }
    }
