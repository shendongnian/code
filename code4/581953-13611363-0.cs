    [Test]
    public void TestFind()
    {
         var etaValue = DateTime.Now.Date.ToShortDateString();
         var visibilities = new List<Visibility> { new Visibility { ETA = etaValue } };
         var foundItem = visibilities.Find(x => x.ETA == etaValue);
         Assert.That(foundItem, Is.Not.Null);
    }
