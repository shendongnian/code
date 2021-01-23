       public List<string> PhoneNumbers { get; set; }
        public List<string> ContactEmails { get; set; }
    
        public GetContactDetails(ContactInformation c)
        {
            PhoneNumbers = new List<string>();
            ContactEmails = new List<string>();
    
            CanShow = Visibility.Visible;
            ContactName = c.Name;
            if (c.PhoneNumbers.Count > 0)
            {
                foreach (var item in c.PhoneNumbers)
                {
                    PhoneNumbers.Add(item.Value);
                }
            }
            else
            {
                CanShow = Visibility.Collapsed;
            }
    
            /// Don't you need the below code somewhere?//////
            if (c.Emails.Count > 0)
            {
                foreach (var item in c.Emails)
                {
                    ContactEmails .Add(item.Value);
                }
            }
    
    ///////////////////////////////////////////////////////////////
            else
            {
                CanShow = Visibility.Collapsed;
            }
            GetContactImage(c);
        }
