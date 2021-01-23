    public static class MyPowerupInfo
    {
      public static Dictionary<PowerUp, int> PowerUps {get; private set;}
      static MyPowerupInfo
      {
        PowerUps = new Dictionary<PowerUp, int>();
        PowerUps.Add(*some power up object goes here*, 0);
        //TODO add other power ups
      }
    }
