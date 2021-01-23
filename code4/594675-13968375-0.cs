        int index = 1;
        foreach(string keys in key.AllKeys)
        {
            DataRow row = Theproducts.NewRow();
            if (keys == ("item_number" + index.ToString()))
            {
                row["ProductID"] = key[keys];
            }
            if (keys == ("item_name" + index.ToString()))
            {
                row["ProductName"] = key[keys];
            }
            Theproducts.Rows.InsertAt(row, 0);
        }
