    [TestMethod]
    public void StripTags_CanStripSingleTag()
    {
        var input = "<p>tag</p>";
        var expected = "tag";
        var actual = HtmlUtilities.StripTags(input, "p");
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void StripTags_CanStripNestedTag()
    {
        var input = "<p>tag <p>inner</p></p>";
        var expected = "tag inner";
        var actual = HtmlUtilities.StripTags(input, "p");
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void StripTags_CanStripTwoTopLevelTags()
    {
        var input = "<p>tag</p> <div>block</div>";
        var expected = "tag block";
        var actual = HtmlUtilities.StripTags(input, "p", "div");
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void StripTags_CanStripMultipleNestedTags_2LevelsDeep()
    {
        var input = "<p>tag <div>inner</div></p>";
        var expected = "tag inner";
        var actual = HtmlUtilities.StripTags(input, "p", "div");
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void StripTags_CanStripMultipleNestedTags_3LevelsDeep()
    {
        var input = "<p>tag <div>inner <p>superinner</p></div></p>";
        var expected = "tag inner superinner";
        var actual = HtmlUtilities.StripTags(input, "p", "div");
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void StripTags_CanStripTwoTopLevelMultipleNestedTags_3LevelsDeep()
    {
        var input = "<p>tag <div>inner <p>superinner</p></div></p> <div><p>inner</p> toplevel</div>";
        var expected = "tag inner superinner inner toplevel";
        var actual = HtmlUtilities.StripTags(input, "p", "div");
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void StripTags_IgnoresTagsThatArentSpecified()
    {
        var input = "<p>tag <div>inner <a>superinner</a></div></p>";
        var expected = "tag inner <a>superinner</a>";
        var actual = HtmlUtilities.StripTags(input, "p", "div");
    
        Assert.AreEqual(expected, actual);
    
        input = "<wrapper><p>tag <div>inner</div></p></wrapper>";
        expected = "<wrapper>tag inner</wrapper>";
        actual = HtmlUtilities.StripTags(input, "p", "div");
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void StripTags_CanStripSelfClosingAndUnclosedTagsLikeBr()
    {
        var input = "<p>tag</p><br><br/>";
        var expected = "tag";
        var actual = HtmlUtilities.StripTags(input, "p", "br");
    
        Assert.AreEqual(expected, actual);
    }
