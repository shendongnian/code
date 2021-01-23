    public abstract class CommonListBase
    {
    }
    public class List1 : CommonListBase, IEnumerable<Class1>
    {
        public System.Collections.Generic.IEnumerator<Class1> GetEnumerator()
        {
            yield return new Class1();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    public class List2 : CommonListBase, IEnumerable<Class2>
    {
        public System.Collections.Generic.IEnumerator<Class2> GetEnumerator()
        {
            yield return new Class2();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
