    class GameDatails
    {
      public Guid Role1 { get; set; } // holds the guid of the player who asks
      public Guid  Role2 { get; set; } // holds the guid of the player who guesses
      public List<KeyValuePair<Guid, string>> Messages; // holds the player/message pairs
      public GameDetails(Guid role1, Guid role2)
      {
        this.Role1 = role1;
        this.Role2 = role2;
        this.Message = new List<KeyValuePair<Guid, string>>();
      }
    }
