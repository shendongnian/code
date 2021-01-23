     Contact thisContact = Utility.GetContactDetailsById(authenticationData, myContact[0].Id);
               // //Add Lists
                ContactOptInList newList = new ContactOptInList();
                //thisContact.OptInSource = ContactOptSource.ActionByCustomer;
                newList.ContactList = new ContactList("39"); //Contact list you want to add them to
                newList.ContactList = new ContactList("10"); //Contact list you want to add them to
                thisContact.ContactLists.Add(newList);
                //Update contact
                Utility.UpdateContactFullForm(authenticationData, thisContact);
               
