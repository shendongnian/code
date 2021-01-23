    public class DoubleSet : List<double>
    {
        public IEnumerable<double> Square()
        {
            return this.Select( x => x*x );
        }
    }
       
