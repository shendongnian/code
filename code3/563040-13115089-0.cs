    public class DiagnosticCollection<T> : System.Collections.Generic.List<T>
    {
        public new Enumerator GetEnumerator()
        {
            Debug.Print("Collection Unwrap");
            return base.GetEnumerator();
        }
    }
