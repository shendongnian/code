    AutoCompleteStringCollection Collection = DatabaseService.Instance.AutoComplete("AuditIT", "AutoComplete", paramListAutoCom);
               foreach (String Item in Collection)
               {
                   comboBox1.Items.Add(Item);
               }
