    public class Evil
    {
        public static bool operator ==(object other)
        {
            return false;
        }
        public static bool operator !=(object other)
        {
            return false;
        }
    }
