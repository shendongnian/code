     // get hash set of contact-only IDs
     var except = new HashSet<int>(contacts
          .Select(c => c.ContactId)
          .Except(emplopyees.Select(e => e.ContactId)));
     // get the objects for those IDs
     var others = contacts.Where(c => except.Contains(c.ContactId)).ToList();
