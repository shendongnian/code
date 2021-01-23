    [Test]
    public void TestInsert()
    {
        var originalString = "some original text";
        var insertString = "_ INSERTED TEXT _";
        var insertOffset = 8;
    
        var file = @"c:\someTextFile.txt";
    
        if (File.Exists(file))
            File.Delete(file);
    
        using (var originalData = new MemoryStream(Encoding.ASCII.GetBytes(originalString)))
        using (var f = File.OpenWrite(file))
            originalData.CopyTo(f);
    
        using (var dataToInsert = new MemoryStream(Encoding.ASCII.GetBytes(insertString)))
            Insert(file, insertOffset, dataToInsert);
    
        var expectedText = originalString.Insert(insertOffset, insertString);
    
        var actualText = File.ReadAllText(file);
        Assert.That(actualText, Is.EqualTo(expectedText));
    }
