    public class NavigationObject
    {
        public int Offset { get; private set; }
        
        public void GoForward()
        {
            Offset++;
        }
        
        public void GoBackwards()
        {
            Offset--;
        }
    }
