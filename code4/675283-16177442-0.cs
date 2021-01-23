    [TestMethod]
    public void TestMethod1()
    {
        string input = "<message Severity=\"Error\">Password will expire in 30 days.\n"
                        +"Please update password using following instruction.\n"
                        +"1. login to abc\n"
                        +"2. change password.\n"
                        +"</message>";
        input = "something other" + input + "something else";
        Regex r = new Regex("<message Severity=\"Error\">Password will expire in 30 days\\..*?</message>", RegexOptions.Singleline);
        input = r.Replace(input, string.Empty);
        Assert.AreEqual<string>("something othersomething else", input);
    }
