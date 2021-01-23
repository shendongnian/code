    public class NullishObjectsToTheBackOfTheLine: IComparer<ClassToCompare>
    {
        private enum Xy
        {
            X = -1,
            Both = 0,
            Y = 1
        };
        
        //the IComparer implementation wraps your readable code in an int cast.
        public int Compare(ClassToCompare x, ClassToCompare y)
        {
            return (int) CompareXy(x, y);
        }
        private static Xy CompareXy(ClassToCompare x, ClassToCompare y)
        {
            if (x == null && y == null) return Xy.Both;
            //put any nulls at the end of the list
            if (x == null) return Xy.Y;
            if (y == null) return Xy.X;
            if (x.Country == y.Country && x.ProductId == y.ProductId) return Xy.Both;
            //put the least amount of at the front
            if (x.ProductId == null && x.Country == null) return Xy.Y;
            if (y.ProductId == null && y.Country == null) return Xy.X;
            //put the country values that are not nulls in front
            if (x.Country != y.Country) return x.Country != null ? Xy.X :  Xy.Y;
            //if we got this far, one of these has a null product id and the other doesn't
            return x.ProductId != null ? Xy.X : Xy.Y;
        }
    }
    public class ClassToCompare
    {
        public string Country { get; set; }
        public string ProductId { get; set; }
    }
