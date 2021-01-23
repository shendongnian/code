        public void CreateUser(User user)
        {
            using (IRepository<User> repository = new DataRepository<User>())
            {
                repository.Add(user);
                repository.SaveChanges();
            }
        }
