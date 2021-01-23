    // In file: game1.cs
    public partial class game
    {
        private int Value;
        public void Initialize()
        {
            Run();
        }
    }
    // In file: game2.cs
    public partial class game
    {
        private void Run()
        {
            Value = 2;  // Access private field.
        }
    }
