    class Foo : ICanHaveMyTextChanged 
    {
        public string StartTime { get; private set; }
        public void ChangeText(string newText)
        {
            StartTime = newText;
        }
    }
