    abstract class GameEntity : Entity2D
    {
      abstract public void TowerOnlyFunction (args); // need to look up exact syntax, but you get the idea
      abstract public void EnemyOnlyFunction (args);
    
      void CommonFunctions (args);
    }
 
    class Tower : GameEntity
    {
      public void TowerOnlyFunction (args)
      {
        // code
      }
      public void EnemyOnlyFunction (args)
      {
        // empty
      }
    }
 
    class Enemy : GameEntity
    {
      public void TowerOnlyFunction (args)
      {
        // empty
      }
      public void EnemyOnlyFunction (args)
      {
        // code
      }
    }
    //Somewhere in the game
    void DoSomethingWithTower ()
    {
      GameEntity e = GetEntity(0);
      e.TowerOnlyFunction ();
    }
