    public class UsesIReady
    {
        public bool Start { get; set; }
        public List<string> WidgetNames { get; set; }
        //Here is the decoupling. Note that any object passed
        //in with type IReady will be accepted in this method
        public void BeginWork(IReady readiness)
        {
            if (readiness.ComputeReadiness())
            {
                Start = true;
                Work();
            }
        }
        private void Work()
        {
            foreach( var name in WidgetNames )
            {
                //todo: build name
            }
        }
    }
