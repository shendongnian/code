              private void clbsec(CheckedListBox clb, string text)
              {
                  for (int i = 0; i < clb.Items.Count; i++)
                  {
                      if(text == clb.Items[i].ToString())
                      {
                          clb.SetItemChecked(i, true);
                      }
                  }
              }
