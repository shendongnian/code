            uICcmbMarketsComboBox.SelectedItem = this.ClientCreationRecParams.UICcmbMarketsComboBoxSelectedItem;
            int x = 0;
            for (int i = 0; i < uIMarketsComboBox.Items.Count; i++)
            {
                if (uIMarketsComboBox.Items[i].Name.ToString() != "ABC123")
                {
                    continue;
                }
                else x = i;
                
            }
            uIMarketsComboBox.SelectedIndex = x
