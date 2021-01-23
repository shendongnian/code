    public class Undergrads
    {
        private List<Undergrad> myList;
        public Undergrad this[EUndergrad index]
        {
            return this.myList[index];
        }
    }
    public enum EUndergrad
    {
        Undergrad_0 = 0,
        Undergrad_1 = 1,
        ...
    }
