            ShellEntities entities = new ShellEntities(); //initiate
            List<User> users = entities.User.Where(w => w.Email == "test@gmail.com").ToList();
            foreach (var item in users)
            {
                Response.Write(item.Username);
            }
