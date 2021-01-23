               else if (switch.Active == true && enemy.Trapped == true
    				&& switch.IsCircleColliding(enemy.EnemyBase.WorldCenter,
    						enemy.EnemyBase.CollisionRadius)
    				)
    			{
    				//When the Player step on Switch-Tile and 
    				//there is an enemy too on this tile which was trapped = Destroy Enemy  
    
    				enemy.Destroyed = true;                            
    			}
