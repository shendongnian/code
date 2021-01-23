         public void Body(object obj, object objInPreviousState)
            {
              const string Address= "aps@somedomain.com"; //extract to configuration
              IEmail item = GetEmailItem(_obj, _objInPreviousState);
              if(item != null) emailService().SendEmails( Address, emails.ToArray(), item.GetMessage(), item.GetSubject() );
            }
    
    
