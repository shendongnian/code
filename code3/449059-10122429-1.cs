    internal sealed class Object : IComparable<Object>
    {
       private readonly int mID; 
       public int ID { get { return mID; } }
       public Object(int pID) { mID = pID; }
       public static implicit operator int(Object pObject) { return pObject.mID; }
       public static implicit operator Object(int pInt) { return new Object(pInt); }
       public int CompareTo(Object pOther) { return mID - pOther.mID; }
       public override string ToString() { return string.Format("{0}", mID); }
    }
    List<Object> myList = new List<Object> { 1, 2, 6, 5, 4, 3 };
 
    // the last item first
    List<Object> last = new List<Object> { myList.Last() };
    List<Object> lastFirst = 
       last.Concat(myList.Except(last).OrderBy(x => x)).ToList();
    lastFirst.ForEach(Console.Write);
    Console.WriteLine();
    // outputs: 312456     
    // or
         
    // the largest item first
    List<Object> max = new List<Object> { myList.Max() };
    List<Object> maxFirst = 
       max.Concat(myList.Except(max).OrderBy(x => x)).ToList();
    maxFirst.ForEach(Console.Write);
    Console.WriteLine();
    // outputs: 612345
