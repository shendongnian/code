    for (int i = 0; i <= AdvLst.Items.Count - 1; i++)
        {
           if (AdvLst.Items[i].Selected)
               {
                  string _value = AdvLst.SelectedItem.Value;
                  string _text = AdvLst.SelectedItem.Text;
                  ListItem item = new ListItem();
                  item.Text = _text;
                  item.Value = _value;
                  SelectedMortLst.Items.Add(AdvLst.Items[i]);
                  AdvLst.Items.Remove(AdvLst.Items[i]);
                  i--;
                }
          }
