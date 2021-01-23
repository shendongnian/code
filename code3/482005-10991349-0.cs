    var c = new NameValueCollection();
    var c2 = new NameValueCollection();
    
    c.Add("test1", "testvalue1");
    c.Add("test2", "testvalue2");
    
    c2.Add("test1", "testvalue1");
    c2.Add("test2", "testvalue2");
    
    c.Should().BeEquivalentTo(c2); // assertion succeeds
