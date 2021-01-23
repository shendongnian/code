    var users = new ArrayList();
           using (var db = new DataClasses1DataContext())
            {
                var query = db.USERS
                foreach (var q in query)
                {
                    users.Add(q);
                }
            }
           return users;
