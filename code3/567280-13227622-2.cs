    public class FormStack : IEnumerable<Form>
    {    
        public Form Form { get; set; }
        public FormStack Parent { get; set; }    
        IEnumerator IEnumerable.GetEnumerator() { return (IEnumerator)GetEnumerator(); }    
        public IEnumerator<Form> GetEnumerator()
        {
            return new FormEnumerator(Form); //implement this
        }
    }
