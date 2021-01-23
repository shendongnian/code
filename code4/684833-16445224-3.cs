    var users = new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "Clark",
                LastName = "Kent"
            },
            new User()
            {
                Id = 2,
                FirstName = "Lex",
                LastName = "Luther"
            }
        };
        users.ForEach(p => context.Users.Add(p));
        var messages = new List<Message>()
        {
            new Message()
            {
                Id = 1,
                SenderId = 2,
                Recipients = new List<User> {context.Users.Where(u=>u.Id==1),context.Users.Where(u=>u.Id==1) }
            }
        }
        messages.ForEach(p => context.Messages.Add(p));         
        context.SaveChanges();
