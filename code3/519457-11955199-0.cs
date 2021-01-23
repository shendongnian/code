    var userContacts = doc2.Root
                           .Descendants()
                           .Select((c, i) => new {Contact = c, Index = i});
    foreach(var indexedContact in userContacts)
    {
         // indexedContact.Contact
         // indexedContact.Index                 
    }
