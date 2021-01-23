    interface I
    {
        void M();
    }
    class C : I
    {
        public int P { get; set; }
        void I.M() { Console.WriteLine("M!"); }
    }
