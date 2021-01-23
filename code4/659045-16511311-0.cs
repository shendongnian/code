    var checkboxes = new List<CheckBox>{checkboxAuctionHistory, checkboxBackSaldo, checkboxBalanceDecrypted}; //And so on
        foreach (var checkbox in checkboxes)
        {
            if (!string.IsNullOrWhiteSpace(checkbox.ID) && checkbox.Checked)
                {
                    arrayDocs.Add(checkbox.ID);
                }
            }
        } 
