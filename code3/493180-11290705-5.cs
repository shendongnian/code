    var doc = new Test
    {
        HeaderText = new[] 
        { 
            new Header { Tag = "AAA" }, 
            new Header { Tag = "BBB" }
        }
    };
    var xml = new XmlSerializer(typeof(Test));
    using (var fs = new FileStream("test.xml", FileMode.Create))
    {
        xml.Serialize(fs, doc);
    }
