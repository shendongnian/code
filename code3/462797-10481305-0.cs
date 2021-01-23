    //need to be defined in your loop
    int nextTankToCreate(0);
    int iterationCount(0);
    int CreateTime(500); //create every 500 iteration
    
    iterationCount++;
    if (spawn == true && iterationCount >= createTime)
            {
                iterationCount = 0;
                maxTanks += 2;
                killsInWave += 2;
    
                tanks = new Tank[maxTanks];
                tanks[nextTankToCreate] = new Tank();
                tanks[nextTankToCreate].Initialize(map);
                tanks[nextTankToCreate].LoadContent(Content);                                  
                nextTankToCreate++;
                if (nextTankToCreate == maxTanks)
                {
                    nextTankToCreate = 0;
                    waveNum += 1;
                    spawn = false;
                }
            }
