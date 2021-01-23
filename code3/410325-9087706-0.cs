    //using Microsoft.Communications.Contacts;
    
    ContactManager theContactManager = new ContactManager();
    foreach (Contact theContact in theContactManager.GetContactCollection())
    {
        string theLine = theContact.Names[0].FormattedName;
        foreach(PhoneNumber theNumber in theContact.PhoneNumbers)
            theLine += "\t" + theNumber.ToString();
        listBox1.Items.Add(theLine);
        //Console.WriteLine(theLine); //Uncomment this if on console
    }
