    string deliveryOffice = string.Empty;
    Outlook.Recipient recipient = mailItem.Application.Session.CreateRecipient(mailItem.SenderEmailAddress);
    if (recipient != null && recipient.Resolve() && recipient.AddressEntry != null) 
    {
        Outlook.ExchangeUser exUser = recipient.AddressEntry.GetExchangeUser();
        if (exUser != null && !string.IsNullOrEmpty(exUser.Alias))
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal up = UserPrincipal.FindByIdentity(pc, exUser.Alias); 
                if (up != null)
                {
                    DirectoryEntry directoryEntry = up.GetUnderlyingObject() as DirectoryEntry;
                    if (directoryEntry.Properties.Contains("physicalDeliveryOfficeName"))
                        deliveryOffice = directoryEntry.Properties["physicalDeliveryOfficeName"].Value.ToString();
                }
            }
        }
    }
