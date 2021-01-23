    for(int i = 0; i<bullet_i_position.count;i++)
      {
         bool hascollided = false;
         for(int j = 0; j<enemy_positions.count;j++)
            {
              if(collisionOccurs)
                   {
                    hasCollided = true;
                    enemy_positions.RemoveAt(j);
                    j--;
                   }
           }
       if(hasCollided)
          {
             bullet_i_position.RemoveAt(i);
             i--;
          }
    }
