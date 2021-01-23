    public class Condition 
    {
        public string Name {get; set;}
        public Func<Move,bool> IsMet {get;set;} 
    }
    // Captures the behaviour of moving diagonally by 1-step
    // This can now be referenced/composed by other classes to build
    // a more complex condition
    var moveDiagonalCondition = new Condition 
    { 
        Name="Move diagonal", 
        IsMet = move => 
                        {
                            var delta = (move.ToPosition - move.FromPosition);
                            // 1 step to the left or right
                            return Math.Abs(delta.X) == 1 
                            // 1 step upwards (if player),
                            // or 1 step downwards (if opponent)
                            && delta.Y == move.IsPlayer1Move ? -1 : 1
                        }
    }
