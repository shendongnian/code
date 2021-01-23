    public List<Room> GetRooms()
    {
        return new List<Room>(){new Room(){Name = "Room1", Time= 10},
                                new Room(){Name = "Room1", Time= 20},
                                new Room(){Name = "Room2", Time= 10},
                                new Room(){Name = "Room2", Time= 30},
                                new Room(){Name = "Room2", Time= 50},
                                new Room(){Name = "Room4", Time= 25},
                                new Room(){Name = "Room3", Time= 50},
                                new Room(){Name = "Room3", Time= 15},
                                new Room(){Name = "Room3", Time= 30},
                                new Room(){Name = "Room3", Time= 40}};
    }
    
    [TestMethod]
    public void CheckSumsLambda()
    {
        var rooms = GetRooms();
        var results = rooms.GroupBy(x => x.Name).Select(x => new { RoomName = x.Key, Occurences = x.Count(), Cumulativetime = x.Sum(y => y.Time) });
    
        Console.WriteLine("Lambda flavour");
        foreach (var result in results)
        {                 
            Console.WriteLine("{0}x {1}  | {2}", result.Occurences, result.RoomName, result.Cumulativetime);               
        }
    
    }
    
    [TestMethod]
    public void CheckSumsLinq()
    {
        var rooms = GetRooms();
        var results = from r in rooms
                        group r by r.Name
                            into g
                            select new { RoomName = g.Key, Occurences = g.Count(), Cumulativetime = g.Sum(y => y.Time) };
    
        Console.WriteLine("Linq flavour");
        foreach (var result in results)
        {
            Console.WriteLine("{0}x {1}  | {2}", result.Occurences, result.RoomName, result.Cumulativetime);
        }
    
    }
