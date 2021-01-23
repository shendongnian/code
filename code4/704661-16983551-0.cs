    var db = new MyContext();
    
    var user = new User();
    user.Name = "John Doe";
    user.Email = "jd@email.com";
    db.Users.Add(user);
    db.SaveChanges();
    
    var follower = db.Users.Where(u => u.Name == "John Doe").FirstOrDefault();
    
    var task = new Task();
    task.Name = "Make the tea";
    task.CreatedAt = DateTime.Now;
    task.Followers =  new Collection<User>()
    task.Followers.Add(follower);
    
    db.Tasks.Add(task);
    
    db.SaveChanges(); 
 
