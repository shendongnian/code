    var rolls = new List<Roll>();
    // run as many rolls as you want. e.g.:
    rolls.Add(new Roll(5));
    var threeOfAKindRolls = rolls.Where(r => r.HasThreeOfAKind());
    public class Roll
    {
         public Roll( int diceCount )
         { 
              DiceResults = new int[diceCount]; // your results.
              // Do your random generation here for the number of dice
             ResultCounts = new int[6]; // assuming 6 sided die
             foreach (var diceResult in DiceResults)
             {
                 ResultCounts[diceResult]++;
             }
         }
         public int[] DiceResults { get; private set; }
         public int[] ResultCounts { get; private set; }
         public bool HasThreeOfAKind()
         {
             return ResultCounts.Any(count => count >= 3);
         }
    }
