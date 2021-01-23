    public class NavigationObject
    {
        public int Offset { get; private set; }
        
        public void GoForwards()
        {
            Offset++;
        }
        
        public void GoBackwards()
        {
            Offset--;
        }
    }
