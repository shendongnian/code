     var messages = new List<Message>()
        {
            new Message()
            {
                Id = 1,
                SenderId = 2,
                Recipients = new List<User> { context.Users.Where(u=>u.Id==2),context.Users.Where(u=>u.Id==1)}
            }
        }
