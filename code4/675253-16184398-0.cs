    [TestFixture]
    public class ErrorDialogHelperTest
    {
        [Test]
        public void UsesShowDelegateToDisplayMessage()
        {
            bool delegateWasCalled = false;
            ShowDelegate mockShowDelegate = delegate(string text, string caption)
            {
                Assert.AreEqual("the expected message", text);
                Assert.AreEqual("the expected title", caption);
                delegateWasCalled = true;
            };
    
            ErrorDialogHelper helper = new ErrorDialogHelper(showDelegate);
    
            helper.ShowErrorMessage("the expected message", "the expected title");
            Assert.IsTrue(delegateWasCalled);
        }
    }
