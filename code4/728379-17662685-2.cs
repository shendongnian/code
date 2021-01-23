    void Main()
    {
        for (int index = 1; index <= 5; index++)
        {
            new NoisyObject(index.ToString());
        }
        for (;;)
        {
            // do something that will provoke the garbage collector
            AllocateSomeMemory();
        }
    }
    
    private static void AllocateSomeMemory()
    {
        GC.KeepAlive(new byte[1024]);
    }
    
    public class NoisyObject
    {
        private readonly string _Name;
    
        public NoisyObject(string name)
        {
            _Name = name;
            Debug.WriteLine(name + " constructed");
        }
    
        ~NoisyObject()
        {
            Debug.WriteLine(_Name + " finalized");
        }
    }
