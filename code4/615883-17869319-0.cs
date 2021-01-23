     // Check if user already exists
                    if (user == null)
                    {
                                     
                        var client = new Facebook.FacebookClient(Session["facebooktoken"].ToString()); 
                        dynamic response = client.Get("me", new { fields = "first_name, last_name, email" });
                        model.FirstName = response["first_name"];
                        model.LastName = response["last_name"];
                        model.EmailAddy = response["email"];
                        
                        
                        // Insert name into the profile table
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName, FullName = model.FullName, Gender = model.Gender, FirstName= model.FirstName, LastName =model.LastName, EmailAddy=model.EmailAddy});
                        db.SaveChanges();
