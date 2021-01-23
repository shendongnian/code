    int attempts = 0;
    
    do //Do-While to ensure that the asteroid gets generated at least once
    {
        attempts++;
        ...
        foreach (GameObject asteroid in Asteroids)
        {
            if (tempAsteroid.BoundingBox.Intersects(asteroid.BoundingBox))
            {
                isOverlap = true;
                break;
            }
        }
    
    } while (isOverlap && attempts < 20); //if overlapping, loop, give up after 20 tries
    
    if (attempts == 20)
    {
    	//log it! Or fix it, or something!
    }
