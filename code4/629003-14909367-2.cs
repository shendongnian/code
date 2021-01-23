    public class myWords : IEnumerable<string>
    {
        ....    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
