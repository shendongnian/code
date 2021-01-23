    public class SemaphoreSlimNamed : SemaphoreSlim
    {
        public string name;
        public SemaphoreSlimNamed(int InitialCapacity, int MaxCapacity) : base(InitialCapacity, MaxCapacity)
        {
        }
    }
