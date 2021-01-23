    public void Attack(Enemy e)
    {
      //do your attack code
    
      //did the enemy die?
      KillEnemy();
      //add exp just for landing a successful attack
      AddExp(e);
    }
    public void AddExp(Enemy e)
    {
      CurrentPlayer.Exp += e.ExperienceGain;
      //update the UI with the new exp
      GameWindow.ExperienceBox.Text = CurrentPlayer.Exp;
    }
