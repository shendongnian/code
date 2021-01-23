    public class myWords : IEnumerable<string>
    {
        string[] f = "I love you".Split(new string[]{"lo"},StringSplitOptions.RemoveEmptyEntries);
    
        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return f.Select(s => s + "2").GetEnumerator();
        }
    
        public IEnumerator GetEnumerator()
        {
            return f.Select(s => s + "3").GetEnumerator();
        }
    }
