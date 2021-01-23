         public Roll( int diceCount )
         {
              // Do your random generation here for the number of dice
             DiceResults = new int[0]; // your results.
         }
         public bool HasThreeOfAKind()
         {
             ResultCounts = new int[6]; // assuming 6 sided die
             foreach (var diceResult in DiceResults)
             {
                 // Increment and shortcut if the previous value was 2
                 if( (ResultCounts[diceResult]++) == 2) return true;
             }
             return false;
         }
