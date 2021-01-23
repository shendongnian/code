    public interface IDo
    {
        void Do(string y);
    }
    
    public class A : IDo
    {
        public void Do(string y)
        {
            switch (y)
            {
                case "1": Do1(); break;
                case "2": Do2(); break;
                case "3": Do3(); break;
            }
        }
    
        private void Do1() { }
        private void Do2() { }
        private void Do3() { }
    }
