    using (var context = new DBEntities())
                {
                    System.Data.Objects.ObjectQuery<User> contacts = context.Users.Where("it.FirstName = @fname", new System.Data.Objects.ObjectParameter("fname", "Arash"));
                    List<User> items = contacts.ToList();
                }
