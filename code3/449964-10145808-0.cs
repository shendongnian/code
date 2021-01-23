            public int UserId;
            public string Name;
            public int GroupId;
            public int CollectionId;
        }
        public class Group
        {
            public int GroupId;
            public string Name;
        }
        public class Collection
        {
            public int CollectionId;
            public string Name;
        }
        static void Main()
        {
            var groups = new[] { 
                new Group { GroupId = 1, Name = "Members" },
                new Group { GroupId = 2, Name = "Administrators" } 
            };
            var collections = new[] { 
                new Collection { CollectionId = 1, Name = "Teenagers" },
                new Collection { CollectionId = 2, Name = "Seniors" } 
            };
            var users = new[] { 
                new User { UserId = 1, Name = "Ivan", GroupId = 1, CollectionId = 1 },
                new User { UserId = 2, Name = "Peter", GroupId = 1, CollectionId = 2 },
                new User { UserId = 3, Name = "Stan", GroupId = 2, CollectionId = 1 },
                new User { UserId = 4, Name = "Dan", GroupId = 2, CollectionId = 2 },
                new User { UserId = 5, Name = "Vlad", GroupId = 1, CollectionId = 2 },
                new User { UserId = 6, Name = "Greg", GroupId = 2, CollectionId = 1 },
            };
            var results = from u in users
                          join g in groups on u.GroupId equals g.GroupId
                          join c in collections on u.CollectionId equals c.CollectionId
                          select new { UserName = u.Name, GroupName = g.Name, CollectionName = c.Name };
        }
