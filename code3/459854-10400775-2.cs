    internal class Thing : IThingy
    {
        public string CanSeeThisValue { get; private set; }
        public Thing(string canSeeThisValue)
        {
            CanSeeThisValue = canSeeThisValue;
        }
        ...
    } 
