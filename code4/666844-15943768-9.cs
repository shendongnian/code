    class Graveyard : ILocation
    {
      IMonsterFactory _monsterFactory;
    
      public Graveyard(IMonsterFactory factory)
      {
        _monsterFactory = factory;
      }
    
      public void PresentLocalCreeps()
      {
        var vampire = _monsterFactory.CreateVampire(300);
        vampire.IntroduceYourself();
    
        var zombie = _monsterFactory.CreateZombie("Rob");
        zombie.IntroduceYourself();
      }
    }
