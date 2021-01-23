    public abstract class Navigator<T> where T : Navigator<T>.Route
    {
        public class Route
        {
        }
    }
    
    public class P2PNavigator : Navigator<P2PNavigator.Route>
    {
        public class Route : Navigator<P2PNavigator.Route>.Route
        {
        }
    }
