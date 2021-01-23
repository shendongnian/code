    public void SaveAltContact(int prospectID, int contactPosition, SecondaryContact contact)
        {
            using (var context = new CoyleHomeBuyerEntities())
            {
                    SecondaryContact currentAltContact;
    
                currentAltContact = (from sec in context.SecondaryContact
                                     where sec.ContactPosition == contactPosition
                                     where sec.ProspectID == prospectID
                                     select sec).FirstOrDefault();
                    
                if (currentAltContact == null)
                {
                    currentAltContact = new Model.SecondaryContact();
                    context.AddToSecondaryContact(currentAltContact);
                }
    
                currentAltContact.FirstName = contact.FirstName;
                currentAltContact.LastName = contact.LastName;
                currentAltContact.EmailAddress = contact.EmailAddress;
                currentAltContact.PhoneNumber = contact.PhoneNumber;
                currentAltContact.SecondaryContactTypeID = contact.SecondaryContactTypeID;
                currentAltContact.ProspectID = prospectID;
                currentAltContact.ContactPosition = contactPosition;
 
                context.SaveChanges();
            }
        }
