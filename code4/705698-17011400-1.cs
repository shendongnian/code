    public class Chromosome : IEquatable<Chromosome>
    {
        // snip
        bool IEquatable<Chromosome>.Equals(Chromosome other)
        {
            // Compare fitness
            if(fitness != other.fitness) return false;
        
            // Make sure we don't get IndexOutOfBounds on one of them
            if(body.Length != other.body.Length) return false;
            for(var x = 0; x < body.Length; x++)
            {
                // IndexOutOfBounds on inner arrays
                if(body[x].Length != other.body[x].Length) return false;
                for(var y = 0; y < body[x].Length; y++)
                    // Compare bodies
                    if(body[x][y] != other.body[x][y]) return false;
            }
            // No difference found
            return true;
        }
        // ReSharper's suggestion for equality members
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals((Chromosome)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.Body != null ? this.Body.GetHashCode() : 0) * 397) ^ this.Fitness.GetHashCode();
            }
        }
    }
