    string contactsRetriveDate = "";
        DateTime a;
        string now = DateTime.Now.ToString("MM/dd/yyyy");
        string then = "";
        do
        {
            contactsRetriveDate = IS.ReadContactsRetriveDate();
            if (contactsRetriveDate != "")
            {
                a = DateTime.ParseExact(contactsRetriveDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                a.ToString("MM/dd/yyyy");
            }
        }
        while(then!=now);
        MessageBox.Show("Estj");
