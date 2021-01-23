    static void Main(string[] args)
    {
        // easy to understand version:
        IA a = new Model();
        IB b = new Model();
        a.Display();
        b.Display();
        // better practice version:
        Model model = new Model();
        (IA)model.Display();
        (IB)model.Display();
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
