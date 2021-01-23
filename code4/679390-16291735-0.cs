            foreach (DataRow row in currDT.Rows)
            {
                foreach (ListItem item in currencyBox.Items)
                {
                    // check here what you get
                    int currencyId= row.Field<int>("CurrencyID");
                    if (item.Value == currencyId.ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
