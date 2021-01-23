    public class testa
    {
        public void display()
        {
            System.Diagnostics.Debug.WriteLine('a');
        }
    }
    
    public class testb : testa
    {
        public new void display()
        {
            System.Diagnostics.Debug.WriteLine('b');
        }
    }
