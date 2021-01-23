    public abstract class Parent
    {
        public static event Action Something;
    
        public static void OnSomething()
        {
            if (Something != null)
            {
                Something();
            }
        }
    }
