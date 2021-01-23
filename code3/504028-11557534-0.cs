    for (int i = 0; i < missilesList.Count(); i++)
        {
            // Stora asteroider
            for (int j = 0; j < asteroidsBigList.Count(); j++)
            {
                if (missilesList.ElementAt(i).Bounds().Intersects(asteroidsBigList.ElementAt(j).Bounds())) // Fel här ??
                {
                    for(int x = 0; x < 2; x++)
                        AddNewSmallAsteroidToList(new AsteroidSmall(content, asteroidsBigList.ElementAt(j).Position));
                    missilesList.RemoveAt(i);
                    // In the first iteration of the outer for loop i=0, so what if the line below is executed
                    // you will get negative index Hope this help
                    i--;
                    asteroidsBigList.RemoveAt(j);
                    j--;
                }
            }
