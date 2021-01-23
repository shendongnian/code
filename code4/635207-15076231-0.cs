    static void Main(string[] args)
    {
        IA a = new Model();
        IB b = new Model();
        a.Display();
        b.Display();
    }
    interface IA
    {
        void Display();
    }
    interface IB
    {
        void Display();
    }
    class Model : IA, IB
    {
        void IA.Display()
        {
            Debug.WriteLine("I am from A");
        }
        void IB.Display()
        {
            Debug.WriteLine("I am from B");
        }            
    }
