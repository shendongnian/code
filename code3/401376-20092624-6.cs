    public class TestMailModel
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Description { get; set; }
    }
    class FakeController : ControllerBase
    {
        protected override void ExecuteCore() { }
    }
