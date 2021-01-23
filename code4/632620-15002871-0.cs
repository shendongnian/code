                User user = new User(); //your custom class
                user.Username = username;
                user.Status = "Lobby";
                List<User> source = new List<User>();
                source.Add(user);
                //add more users here
    
                listBox.ItemsSource = source;
                //removing a user
                source.Remove(user);//if you have the instance
                //if not, find user by username and remove it
                User userToRemove = null;
                foreach (User user in source) {
                    if (user.Username == "myUserName") { 
                        userToRemove = user;
                        break;
                    }
                }
                if(userToRemove != null)
                    source.Remove(userToRemove);
