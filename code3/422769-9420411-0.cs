    // I made up my own Sentence type
    Sentence current = null;
    var whenNull = new Sentence() {Text = "Hello World!"};
    var original = Interlocked.CompareExchange(ref current, new Sentence() { Text = "Hello World!" }, null);
    Assert.AreEqual(whenNull.Text, current.Text);
    Assert.IsNull(orig);
    // try that it won't override when not null
    current.Text += "!";
    orig = Interlocked.CompareExchange(ref current, new Sentence() { Text = "Hello World!" }, null);
    Assert.AreEqual("Hello World!!", current.Text);
    Assert.IsNotNull(orig);
