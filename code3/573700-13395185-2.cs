    int counter = 1;
    int limit = 50;
    float countDuration = 2f; //every  2s.
    float currentTime = 0f;
            
    currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds; //Time passed since last Update() 
   
    if (currentTime >= countDuration)
    {
        counter++; // increment counter
        currentTime -= countDuration; // "use up" the time
        //any actions to perform
    }
    if (counter >= limit)
    {
        counter = 0;//Reset the counter;
        //any actions to perform
    }
