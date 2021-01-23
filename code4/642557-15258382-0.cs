        [Test]
        public void TestDate()
        {
            var publicationDate = DateTime.ParseExact("03/04/2013", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Assert.AreEqual(4, publicationDate.Day);
            Assert.AreEqual(3, publicationDate.Month);
            Assert.AreEqual(2013, publicationDate.Year);
        }
