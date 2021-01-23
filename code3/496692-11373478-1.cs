    namespace Permutation
    {
        using System;
        using System.Collections.Generic;
    
        public class ThreeDice : IEquatable<ThreeDice>
        {
            public ThreeDice(int dice1, int dice2, int dice3)
            {
                this.Dice = new int[3];
                this.Dice[0] = dice1;
                this.Dice[1] = dice2;
                this.Dice[2] = dice3;
            }
    
            public int[] Dice { get; private set; }
    
            // IEquatable implements this method. List.Contains() will use this method to see if there's a match.
            public bool Equals(ThreeDice other)
            {
                // Get the current dice values into a list.
                var currentDice = new List<int>(this.Dice);
    
                // Check to see if the same values exist by removing them one by one.
                foreach (int die in other.Dice)
                {
                    currentDice.Remove(die);
                }
    
                // If the list is empty, we have a match.
                return currentDice.Count == 0;
            }
    
            public override string ToString()
            {
                return "<" + this.Dice[0] + "," + this.Dice[1] + "," + this.Dice[2] + ">";
            }
        }
    }
