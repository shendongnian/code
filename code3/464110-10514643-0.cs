    public class MyClass
    {
        private IMessageBox _MessageBox;
        public MyClass(IMessageBox messageBox)
        {
            _MessageBox = messageBox;
        }
        public bool MyMethod(string arg)
        {
            var result = _MessageBox.ShowDialog();
            return result == DialogResult.Ok;
        }
    }
    internal class MessageBoxStub : IMessageBox
    {
        DialogResult Result {get;set;}
        public DialogResult ShowDialog()
        {
            return Result;
        }
    }
    [Test]
    public void MyTest()
    {
        var messageBox = new MessageBoxStub() { Result = DialogResult.Yes }
        var unitUnderTest = new MyClass(messageBox);
        Assert.That(unitUnderTest.MyMethod(null), Is.True);
    }
