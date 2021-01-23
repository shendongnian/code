     using (var client = new UserServicesClient())
     {
         var list = new AutoCompleteStringCollection();
         list.AddRange(client.ListNames(query).ToArray());
         comboBoxName.AutoCompleteCustomSource = list;
     }
