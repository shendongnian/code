     private void UpdateComboBox(ComboBox Box, string Group, List<string> Numbers)
            {
                  Box.Items.Clear();
                  Box.BeginUpdate();            
                  Box.Items.Add("<<Add Contact>>");
                  foreach (string item in Numbers)
                  {
                       if(item != "")
                            Box.Items.Add(item);
                  }
              Box.EndUpdate();
              Box.ResetText();
            }
