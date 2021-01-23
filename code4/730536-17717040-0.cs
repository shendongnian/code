    foreach (DataRow recipientRow in ds.Tables[5].Rows)
    {
        // We don't need to fetch this multiple times, or trim them each time.
        string[] recipients = ((string) recipientRow["RecipientId"])
            .Split(',')
            .Select(x => x.Trim())
            .ToArray();
        // It's possible that you could use a foreach loop here, but
        // we don't know the type of chkPrdRecipients...
        for (int i = 0; i < chkPrdRecipients.Items.Count; i++)
        {
            var item = chkPrdRecipients.Items[i];
            foreach (var recipient in recipients)
            {
                if (recipient.Equals(item.Value.Trim(), 
                                     StringComparison.InvariantCultureIgnoreCase))
                {
                    item.Selected = true;
                    break; // No need to check the rest of the recipients
                }
            }
        }
    }
