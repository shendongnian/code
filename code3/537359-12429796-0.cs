            for (int i = 0; i < chBoxListTables.Items.Count; i++)
            {
                if (chBoxListTables.Items[i].Selected)
                {
                    string str = chBoxListTables.Items[i].Text;
                    MessageBox.Show(str);
                    var itemValue = chBoxListTables.Items[i].Value;
                }
            }
