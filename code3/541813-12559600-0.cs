    public class Transition<TState, TCommand>
        : IEquatable<Transition<TState, TCommand>>
    {
        // I assume in reality these are properties?
        TState From = default(TState);
        TState To  = default(TState);
        TCommand Command = default(TCommand);
        public override bool Equals(object other)
        {
            return Equals(other as Transition<TState, TCommand>);
        }
        public bool Equals(Transition<TState, TCommand> other)
        {
            if (other == null)
            {
                return false;
            }
            return From.Equals(other.From) &&
                   To.Equals(other.To) &&
                   Command.Equals(other.Command);
        }
        public int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + From.GetHashCode();
            hash = hash * 31 + To.GetHashCode();
            hash = hash * 31 + Command.GetHashCode();
            return hash;
        }
    }
