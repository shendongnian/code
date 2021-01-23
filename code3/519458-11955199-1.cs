    var userContacts = doc2.Root
                           .Descendants()
                           .Where(element => element.Name == "Contact")
                           .Select((c, i) => new {Contact = c, Index = i});
    foreach(var indexedContact in userContacts)
    {
         // indexedContact.Contact
         // indexedContact.Index                 
    }
