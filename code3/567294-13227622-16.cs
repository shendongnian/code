    public class FormStack : IEnumerable<Form> 
    {    
        public Form Form { get; set; }
        public FormStack Parent { get; set; }  
        public IEnumerator IEnumerable:GetEnumerator() 
        { 
            return (IEnumerator)GetEnumerator();
        }
        public IEnumerator<Form> GetEnumerator() 
        { 
            return new FormStackEnumerator(this);
        }
    }
    public class FormStackEnumerator : IEnumerator<Form>
    {
        private FormStack _stack;
        private FormStack _first;
        public Form Current { get { return _stack.Form; } }
        object IEnumerator.Current { get { return Current; } }
        public FormStackEnumerator(FormStack stack)
        {
            _stack = stack;
            _first = stack;
        }
        public bool MoveNext()
        {
            if (_stack.Parent == null)
            {
                return false;
            }
            _stack = _stack.Parent;
            return true;
        }
        public void Reset() { _stack = _first; }
        void IDisposable.Dispose() { }
    }
