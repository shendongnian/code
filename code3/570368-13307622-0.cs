    class Program
    {
        static void Main(string[] args)
        {
            IGenericInterface<int> x = new ImplementingClass<int>();
            Console.WriteLine("Created x and invoking...");
            x.InvokeEvent();
            Console.WriteLine("Adding event and invoking...");
            x.Event += x_Event;
            x.InvokeEvent();
            Console.WriteLine("Removing event and invoking...");
            x.Event -= x_Event;
            x.InvokeEvent();
            Console.WriteLine("Done.");
            Console.ReadKey(true);
        }
        static void x_Event(object sender, NormalEventArgs e)
        {
            Console.WriteLine("Event Handled!");
        }
    }
    interface IBaseInterface<T> where T : EventArgs
    {
        event EventHandler<T> Event;
        void InvokeEvent();
    }
    interface INormalInterface : IBaseInterface<NormalEventArgs>
    {
    }
    interface IGenericInterface<T> : IBaseInterface<GenericEventArgs<T>>
    {
    }
    class ImplementingClass<T> : IGenericInterface<T>
    {
        public event EventHandler<GenericEventArgs<T>> Event;
        public void InvokeEvent()
        {
            if (Event != null)
            {
                Event(this, new GenericEventArgs<T>());
            }
        }
    }
    class NormalEventArgs : EventArgs
    {
    }
    class GenericEventArgs<T> : NormalEventArgs
    {
    }
