    [Test] public void GivenWhenIntegerString_WhenTryParse_ThenValidInteger()
    {
        Dictionary<string, Object> fakeSession  = new Dictionary<string, object>();
        fakeSession["SubCategory"] = "5";
        decimal tmp;
        decimal? IdSubCategory = null;
        if (decimal.TryParse((string)fakeSession["SubCategory"], out tmp))
            IdSubCategory = tmp;
        Assert.That(IdSubCategory, Is.EqualTo(5d));
    }
    [Test] public void GivenWhenNull_WhenTryParse_ThenNull()
    {
        Dictionary<string, Object> fakeSession  = new Dictionary<string, object>();
        fakeSession["SubCategory"] = null;
        decimal tmp;
        decimal? IdSubCategory = null;
        if (decimal.TryParse((string)fakeSession["SubCategory"], out tmp))
            IdSubCategory = tmp;
        Assert.That(IdSubCategory, Is.EqualTo(null));            
    }
