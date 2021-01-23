    [TestMethod]
    public void TestSplitAndReJoin()
    {
      //note - mutator does nothing
      Assert.AreEqual("a,b", SplitAndReJoin("a,b", ",".ToCharArray(), s => s));
      //insert a 'z' in front of every sub string.
      Assert.AreEqual("zaaa,zbbbb.zccc|zdddd:zeee", SplitAndReJoin("aaa,bbbb.ccc|dddd:eee",
        ",.|:".ToCharArray(), s => s.Select(ss => "z" + ss).ToArray()));
      //re-ordering of delimiters + mutate
      Assert.AreEqual("zaaa,zbbbb.zccc|zdddd:zeee", SplitAndReJoin("aaa,bbbb.ccc|dddd:eee",
        ":|.,".ToCharArray(), s => s.Select(ss => "z" + ss).ToArray()));
      //now how about leading or trailing results?
      Assert.AreEqual("a,", SplitAndReJoin("a,", ",".ToCharArray(), s => s));
      Assert.AreEqual(",b", SplitAndReJoin(",b", ",".ToCharArray(), s => s));
    }
