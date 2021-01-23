    class MyControllerTest
    {
        private readonly MyController _controller;
        public MyControllerTest()
        {
            var testSession = new TestSession();
            var _controller = new MyController(testSession);
        }
    }
