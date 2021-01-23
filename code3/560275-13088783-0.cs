        public sendMail(string sMailAccount)
        {
            session = new OutlookSession();
            //eMail = new EmailMessage();
            bool bFound = false;
            foreach (Account acc in session.EmailAccounts)
            {
                System.Diagnostics.Debug.WriteLine(acc.Name);
                if (acc.Name == sMailAccount)
                    bFound = true;
            }
            if (bFound)
                account = session.EmailAccounts[sMailAccount];
            if (account != null)
                _bIsValidAccount = true;
        }
        ...
