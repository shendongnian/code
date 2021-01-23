    using (MyContextdb = new MyContext())
    {
      WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
      // assumes you have moved UserProfile to MyContext, alter code accordingly if not
      UserProfile userProfile = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
      AttributesForUser newAttribs = new AttributesForUser { 
        UserId = userProfile.UserId,
        ... fill in other properties here ... 
      };
      db.AttributesForUsers.Add(newAttribs);
      // do as many more newAttribs as you need for this userId
      ...
      // and now save
      db.SaveChanges();
    }
