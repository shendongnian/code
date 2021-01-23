    async void TestMethod()
    {
       await txtTester.WriteText("Hello World"));
       Task.Factory.StartNew(() => btnTester.Click(1)); // probably sould be refactored too
    }
