    public static class Extension
    {
        public static MyViewModel ToModel(this MyEntity x)
        {
            return new MyViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName,
                UserId = x.User?.Id
            };
        }
    }
