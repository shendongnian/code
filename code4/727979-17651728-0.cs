     DateTime toDate = DateTime.Now;
        
                    string contactsRetriveDate = IS.ReadContactsRetriveDate();
                    DateTime contactsRetriveDat = Convert.ToDateTime(contactsRetriveDate);
                    if (contactsRetriveDate == "" || toDate.CompareTo(contactsRetriveDat)==0)
                    {
                        MessageBox.SHow("");
                    }
                    
