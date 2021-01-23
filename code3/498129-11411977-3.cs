    public class DoubleString : IEnumerable
    {
        public int Length;
        List<String> listA;
        List<String> listB;
        List<string>.Enumerator eA,eB;
        public DoubleString(List<String> newA,List<String> newB)
        {
            if(newA.Count != newB.Count) {
                throw new Exception("Lists lengths must be the same");    
            }
            listA = newA;
            listB = newB;
            eA = listA.GetEnumerator ();
            eB = listB.GetEnumerator ();
            Length = listA.Count;
        }
        IEnumerator IEnumerable.GetEnumerator ()
        {
            return (IEnumerator)new DoubleStringEnumerator(this);
        }
        public string[] getNext ()
        {
            eA.MoveNext ();
            eB.MoveNext ();
            return new string[] {eA.Current ,eB.Current };
        }
    }
