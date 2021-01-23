    partial void UnusedContactTypesByContact_PreprocessQuery(int? ContactID, ref IQueryable<ContactType> query)
        {
            query = from contactType in query
                    where !contactType.ContactToContactTypes.Any(c => c.Contact.Id == ContactID)
                    select contactType;
        }
