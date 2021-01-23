    [Test]
    public void Test()
    {
        string xml = "foo 1234567890123456 bar";
        Debug.WriteLine(Regex.Replace(xml, @"\b\d{9,12}(?=\d{4}\b)", m => new string('*', m.Value.Length)));
    }
