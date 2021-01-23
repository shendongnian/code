    class Game1
    {
        List<Rectangle> cardSpriteAreas; // this is where you store the card's areas
    
        public void Update()
        {
             Point position = GetInterestingPosition(); // this is the point you want to check
             foreach(var spriteArea in cardSpriteAreas)
             {
                  if (spriteArea.Contains(position))
                  {
                       // position is contained within the card's area!
                  }
             }
        }
    }
