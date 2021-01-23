            MailMessage m = new MailMessage();
            GetPeopleList().Aggregate((result, iter) =>
                {
                    m.Bcc.Add(new MailAddress(iter.EmailAddress));
                    return result;
                });
