            ListItem listItem = null;
            while (reader.Read())
            {
                listItem = new ListItem(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString());
                this.lbxCustomers.Items.Add(listItem);,
                lbxCustomers.SelectedItem = listItem;
            }
