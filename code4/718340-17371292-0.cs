      var autoCompleteBox = (item.FindControl("acCompany") as RadAutoCompleteBox);
        int idCompany = 0;
        if (autoCompleteBox !=null)
        {
           foreach (AutoCompleteBoxEntry entry in autoCompleteBox.Entries)
                    {
                        if (entry.Text == autoCompleteBox.Text)
                        {
                            idCompany = Convert.ToInt32(entry.Value);
                            break;
                        }
                    }
        }
