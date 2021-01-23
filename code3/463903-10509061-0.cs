    Outlook.Items oItems = oContacts.Items;
    using(System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\EmailAddress.txt"))
    {
        for (int i = 0; i < oItems.Count; i++)  // Note < instead of <=
        {
            // Will be null if oItems[i] is not a ContactItem
            Outlook.ContactItem oAppt = oItems[i] as Outlook.ContactItem;
            
            if(oAppt != null)
                file.WriteLine(oAppt.Email1Address);
        }
    }
    file.Close();
    oNS.Logoff();
