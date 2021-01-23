    public class Evil
    {
        public static bool operator ==(Evil lhs, Evil rhs)
        {
            return false;
        }
    
        public static bool operator !=(Evil lhs, Evil rhs)
        {
            return false;
        }
    }
