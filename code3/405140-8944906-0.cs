    [TestMethod]
    public void SimpleEvaluationUsingScriptEngine()
    {
        ScriptEngine engine = new ScriptEngine();
        int result = engine.Execute<int>("1 + 2");
        Assert.AreEqual(3, result);
    }
