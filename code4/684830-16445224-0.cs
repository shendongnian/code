     var messages = new List<Message>()
        {
            new Message()
            {
                Id = 1,
                SenderId = 2,
                Recipients = new List<User> {users[0],users[1] }  // <<< Problem is here
            }
        }
