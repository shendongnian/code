    public class SomeServiceWrapper : ISomeService
    {
        private readonly SomeService _containedService;
        public event EventHandler SomeEvent;
        public SomeServiceWrapper()
        {
            _containedService = new SomeService();
            _containedService.SomeEvent += (o, e) => RaiseSomeEvent(e);
        }
        public void DoStuff()
        {
            _containedService.DoStuff();
        }
        private void RaiseSomeEvent(EventArgs e)
        {
            EventHandler evt = SomeEvent;
            if (evt != null)
            {
                evt(this, e);
            }
        }
    }
