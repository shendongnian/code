    List<iEnemy> enemies = new List<iEnemy>();
    enemies.Add(new Troll());
    enemies.Add(new Ogre());
    
    foreach(iEnemy e in enemies)
    {
        e.Move();
    }
    //Output would be:
    //troll move!
    //ogre move!
