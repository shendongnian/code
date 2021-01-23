    public class Base
    {
        public virtual int Datum { get; set; }
    }
    public class Derived : Base
    {
        public override int Datum
        {
            get { return 12; }
            // set method remains as normal, with just the get overriden
        }
        public void SetDatumMethod(int newValue)
        {
            Datum = newValue; // Datum as a property is still accessible
        }
    }
