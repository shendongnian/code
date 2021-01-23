    for (int i=0; i<5; i++)
    {
         Vector2 newPosition = NewRandomPosition;
         if (occupiedPositions[(int)newPosition.X, (int)newPosition.Y] == false)
         {
              listHouseParts.Add(new HousePart(content, 
                                               contentHouseOne[i], 
                                               newPosition));
              occupiedPositions[(int)newPosition.X, (int)newPosition.Y] = true;
         }
    }
