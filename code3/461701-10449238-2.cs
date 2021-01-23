    [TestMethod]
    public void RedactTextLinqNoPartials() {
        var arrToCheck = new string[] { "try", "yourself", "before" };
        var input = "Did you try this yourself before asking";
        
        var output = string.Join(" ",input.Split(' ').Where(wrd => !arrToCheck.Contains(wrd)));
            
        Assert.AreEqual("Did you this asking", output);
    }
