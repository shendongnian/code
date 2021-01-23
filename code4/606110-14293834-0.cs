    public User()
    {
        Games = new List<Game>();
        Stats = new UserStats { Rating = 1500 };
        FriendList = new List<User>(); // <<<--- missing
     }
