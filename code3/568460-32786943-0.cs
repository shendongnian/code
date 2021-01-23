    var users = Mongo.db.GetCollection<User>("Users");
                    var r = users(m => m._id == yourIdHere).Project(m =>
                    new { m._id, m.UserName, m.FirstName, m.LastName }).Limit(1);
    
    Console.WriteLine(users.ToString());
