    public class Project
    {
        public delegate void InvalidateEventHandler();
        public event InvalidateEventHandler Invalidated;
        private void InvalidateMyself() { if (Invalidated != null) Invalidated(); }
        public void HeftyComputation() { Thread.Sleep(2000); }
        public void SimulateUserDoingStuff()
        {
            Thread.Sleep(100);
            InvalidateMyself();
            Thread.Sleep(100);
            InvalidateMyself();
            Thread.Sleep(100);
            InvalidateMyself();
        }
        public Project() { }
    }
