    public class InterfaceComponent
    {
        private static List<InterfaceComponent> zOrder = new List<InterfaceComponent>();
        
        // Class Members....
        
        public InterfaceComponent()
        {
            // Construct class...
            zOrder.Add(this);
        }
        
        private void SetZOrder(int order)
        {
            if (order < 0 || order >= zOrder.Count)
                return;
            zOrder.Remove(this);
            zOrder.Insert(order, this);
            // There are more efficient ways, but you get the idea.
        }
        public void SendBack() { SetZOrder(zOrder.indexOf(this) + 1); }
        public void SendToFront() { SetZOrder(0); }
        // etc...
    }
