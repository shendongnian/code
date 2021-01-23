    public abstract class AnimalBase {
        public abstract string Name { get; } // user-readable
        public abstract double Weight { get; }
        public abstract Habitat Habitat { get; }
        public void Swim(); { /* swim implementation; the same for all animals but uses the value of Weight */ }
        // ensure that two instances of the same type are equal
        public override bool Equals(object o)
        {
            return o != null && o.GetType() == this.GetType();
        }
        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }
    }
    // subclasses store no data; they differ only in what their properties return
    public class Otter : AnimalBase
    {
        public override string Name { return "Otter"; }
        public override double Weight { return 10; }
        // here we use a private static member to hold an instance of a class
        // that we only want to create once
        private static readonly Habitat habitat = new Habitat("North America");
        public override Habitat Habitat { return habitat; }
    }
