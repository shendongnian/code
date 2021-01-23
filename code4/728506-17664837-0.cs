    void Main()
    {
        int i = 0;
        bool b = i.GiveMeYourPet<bool, int>();
    }
    
    public static class MyExtensions
    {
        public static T GiveMeYourPet<T, P>(this P self)
        {
            return default(T);
        }
    }
