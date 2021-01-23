    var messages = new List<Message>()
        {
            new Message()
            {
                Id = 1,
                SenderId = 2,
                Recipients = new List<User>()
                {
                   users.Single(u => u.Id == 1),
                   users.Single(u => u.Id == 2)
            }
        }
