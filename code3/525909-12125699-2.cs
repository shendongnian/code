    abstract class Brush
    {
        protected abstract Brush PrepareCopy();
        // replacement for public default ctor; prepares a copy of the derived brush
        // where all private members have been copied into the new, returned instance.
        public Brush Copy()
        {
            // (1) let the derived class prepare a copy of itself with all inaccessible
            //     members copied:
            Brush copy = PrepareCopy();
            // (2) let's copy the remaining publicly settable properties:
            copy.TypeOfHair = this.TypeOfHair;
            copy.NumberOfHairs = this.NumberOfHairs;
            return copy;
        } 
    }
    sealed class FooBrush : Brush
    {
        public FooBrush(int somethingPrivate)
        {
            this.somethingPrivate = somethingPrivate;
            // might initialise other members here…
        }
        private readonly int somethingPrivate;
        protected override Brush PrepareCopy()
        {
            return new FooBrush(somethingPrivate);
        }
    }
