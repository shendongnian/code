    class A
    {
        private event Action _event;
        public event Action Event { add { _event += value; } remove { _event -= value; } }
        int counter = 0;
        public void AddOne()
        {
            counter++;
            if (counter > 0)
            {
                OnEvent();
            }
        }
        private void OnEvent()
        {
            if (_event != null)
                _event();
        }
    }
    class Program
    {
        int Main()
        {
            string outsidestring = "THE CLASS HAS NO IDEA WHO I AM";
            A a = new A();
            a.Event += new Action(()=>Console.WriteLine(outsidestring));
            while (true)
            {
                Console.ReadLine();
                a.AddOne();
            }
        }
    }
