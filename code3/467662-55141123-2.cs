    using (MyDataBaseEntities db = new MyDataBaseEntities())
        {
                {
                    if (db.People.Any(p => p.FirstName == FirstNameText.Text && p.LastName == LastNameText.Text))
                                {
                                     //Do something
                                }
                }      
        }
