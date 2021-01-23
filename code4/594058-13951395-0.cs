    // do this for each rfv
    WatiN.Core.Span rfvAddress1Line1 = Document.Span("ctl00_Container_rfvAddress1Line1");
    Assert.IsTrue(rfvAddress1Line1.Exists);
    Assert.AreEqual("Some Error Message", rfvAddress1Line1.Text);
    // alternatively, if all of the messages were the exact same, you could do this
    var spans = Document.Spans.Where(s => s.Text == "Some Error Message");
    Assert.AreEqual(4, spans.Count());
