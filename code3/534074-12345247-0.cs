            // Save merchant account & bank information into database
            using (var context = new MyContext())
            {
                try
                {
                    context.Accounts.Add(accounts);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
