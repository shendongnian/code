    public class Evil
    {
        public static bool operator ==(Evil me, object other)
        {
            return false;
        }
    
        public static bool operator !=(Evil me, object other)
        {
            return false;
        }
    }
