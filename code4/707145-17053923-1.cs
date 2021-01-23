        class Dice
        {
          public int publicMinNum { get; set; }
          public int publicMaxNum { get; set; }
          Random diceRoll = new Random();
          public int rolled = diceRoll.Next(publicMinNum , publicMaxNum );
        }
