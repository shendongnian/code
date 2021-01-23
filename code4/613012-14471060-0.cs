    bool hitOrMiss(Entity attacker, Entity defender)
    {
      // do your calcs
    }
    
    int doAttack(Entity attacker, Entity defender)
    {
      if (hitOrMiss(attacker, defender)) {
        // calculate damage
        return dmg;
      }
      else
        return 0;
    }
    
    private void attachPhase(object sender, EventArgs e)
    {
      Player player = ...
      Monster monster = ...
    
      int playerDmg = doAttack(player, monster);
      int monsterDmg = doAttack(monster, player);
    
      if (playerDmg > 0) {
        
      }
    
      if (monsterDmg > 0) {
    
      }
    }
