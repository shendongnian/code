       SpawnUnitsCount = n;
       Units_Per_Second = 5; // 5 Per second
       void Update(float ElapsedSeconds)  // (float) gametime.ElapsedTime.TotalSeconds
       {      
        if (SpawnUnitCount>0)
        {
          CreationRate += Units_per_second * ElapsedSeconds;
          while ( CreationRate >= 1 )
          {
             CreationRate--;
             MakeNewUnit(); 
             SpawnUnitsCount --;
             if (SpawnUnitCount == 0)
             {
                CreationRate = 0; // The wave is finished
             }
          }
        }
