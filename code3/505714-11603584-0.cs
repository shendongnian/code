    var query = (from c in db.TableEmails 
                join o in db.TableSentEmailRecordson c.EmailId equals o.EmailId
                            select new CustomEmail
                            {
                                EmailName = c.EmailName,
                                EmailId= c.EmailId,
                                EmailDescription= c.EmailDescription,
                                LastDateEmailSentOut = o.SentDate
                            }).OrderByDescending(c=>c.LastDateEmailSentOut).ToList();
