     class QueryJoin
    {
        static void Main(string[] args)
        {
            //create users
            User user1 = new User { Id = 1, Name = "anuo1" };
            User user2 = new User { Id = 2, Name = "anuo2" };
            User user3 = new User { Id = 3, Name = "anuo3" };
            User user4 = new User { Id = 4, Name = "anuo4" };
            User user5 = new User { Id = 5, Name = "anuo5" };
            //create objAList
            List<ObjA> objAList = new List<ObjA>();
            objAList.Add(new ObjA { user = user1 });
            objAList.Add(new ObjA { user = user2 });
            objAList.Add(new ObjA { user = user3 });
            //create objBList
            List<ObjB> objBList = new List<ObjB>();
            objBList.Add(new ObjB { user = user3 });
            objBList.Add(new ObjB { user = user4 });
            objBList.Add(new ObjB { user = user5 });
            //intersect
            var result = (from objA in objAList
                          join objB in objBList on objA.user.Id equals objB.user.Id
                          select objA/*or objB*/).ToList();
        }
    }
    class ObjA
    {
        public User user { get; set; }
    }
    class ObjB
    {
        public User user { get; set; }
    }
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
