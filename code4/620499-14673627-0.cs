    interface IRace  //or a base class, as deemed appropriate
    {
        void DoSomething();
    }
    class Orc : IRace
    {
        public void DoSomething()
        {
            // do things that orcs do
        }
    }
    
    class Elf : IRace
    {
        public void DoSomething()
        {
            // do things that elfs do
        }
    }
