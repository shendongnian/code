        [TestCase("3/4/2013", 3, 4, 2013)]
        [TestCase("11/4/2013", 11, 4, 2013)]
        public void DateTest(string date, int month, int day, int year)
        {
            var publicationDate = DateTime.ParseExact(date, "M/d/yyyy", CultureInfo.InvariantCulture);
            Assert.AreEqual(day, publicationDate.Day);
            Assert.AreEqual(month, publicationDate.Month);
            Assert.AreEqual(year, publicationDate.Year);
        }
