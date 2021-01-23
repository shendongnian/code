    Parallel.ForEach(Contacts.items, items =>
                {
                    try
                    {
                        ServiceReference1.Addressbooks ad = new ServiceReference1.Addressbooks();
                        ad.FirstName = (string)items.FirstName;
                        ad.JobTitle = (string)items.JobTitle;
                        ad.MobileTelephoneNumber = (string)items.MobileTelephoneNumber;
                        ad.BusinessTelephoneNumber = (string)items.BusinessTelephoneNumber;
                        ad.BusinessFaxNumber = (string)items.BusinessFaxNumber;
                        ad.Email1Address = (string)items.Email1Address;
                        ad.Body = items.Body.Length > 999 ? (items.Body).Substring(0, 999) : items.Body;
                        ad.CompanyName = (string)items.CompanyName;
                        ad.LastModificationTime = (DateTime)items.LastModificationTime;
                        list.Add(ad);
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                });
