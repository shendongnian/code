    public class BPublisher : B
    {
        public readonly StringBuilder chars = new StringBuilder();
    
        public virtual new char DoSomethingElse(char charToChange)
        {
            chars.Append(charToChange);
            return charToChange;
        }
    }
    
    var a = new BPublisher();
    a.DoSomething("abc");
    Assert.AreEqual("abc", a.chars.ToString());
