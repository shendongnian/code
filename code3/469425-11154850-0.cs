        private IMessengerContact FindContact(string userID)
    {
        IMessengerContact contact = null;
        // Try the local contact list first
        try
        {
            contact = (IMessengerContact)communicator.GetContact(userID, "");
        }
        catch
        {
            contact = null;
        }
    
        // For a nonlocal contact, try the SIP Provider of Communicator
        if (contact == null || contact.Status == MISTATUS.MISTATUS_UNKNOWN)
        {
            try
            {
                contact =
                    (IMessengerContact)communicator.GetContact(userID,
                    communicator.MyServiceId);
                return contact;
            }
            catch
            {
                contact = null;
                return contact;
            }
        }
        else
        {
            return contact;
        }
    }
