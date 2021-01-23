    using (var manager = new FriendManager())
    {
    var id = manager.CreateFriend("John", "Fischer");
    manager.SaveChanges();
    var john = manager.GetFriend(id);
    Console.WriteLine("My new friend {0}.", john.Name);
    }
