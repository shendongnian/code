      AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        namesCollection.Add(reader.GetString(0));
                    }
                    reader.Close();
        descriptionBox.AutoCompleteMode = AutoCompleteMode.Suggest;
    descriptionBox.AutoCompleteSource = AutoCompleteSource.CustomSource;    
                    descriptionBox.AutoCompleteCustomSource = namesCollection;
                    con.Close();
