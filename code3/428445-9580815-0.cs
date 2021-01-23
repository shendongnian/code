    interface IEnemy
    {
     Point3D Position
     {
      get;
      set;
     }
    
     void Destroy();
    }
    
    void FireBomb(Bomb bomb, Point3D impactLocation)
    {
     IEnumerable<IEnemy> affectedEnemies = 
      FindServices<IEnemy>.Where(x.Location - impactLocation <= bomb.BlastedArea);
    
     Execute(affectedEnemies, x => x.Destroy());
    }
