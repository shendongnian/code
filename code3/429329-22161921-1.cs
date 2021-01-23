    [TestFixture]
    class IntegerExtensionTests
    {
        [Test]
        public void TestCases_1s_10s_100s_1000s()
        {
            Assert.AreEqual("1st", 1.AsOrdinal());
            Assert.AreEqual("2nd", 2.AsOrdinal());
            Assert.AreEqual("3rd", 3.AsOrdinal());
            foreach (var integer in Enumerable.Range(4, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
            Assert.AreEqual("11th", 11.AsOrdinal());
            Assert.AreEqual("12th", 12.AsOrdinal());
            Assert.AreEqual("13th", 13.AsOrdinal());
            foreach (var integer in Enumerable.Range(14, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
            
            Assert.AreEqual("21st", 21.AsOrdinal());
            Assert.AreEqual("22nd", 22.AsOrdinal());
            Assert.AreEqual("23rd", 23.AsOrdinal());
            foreach (var integer in Enumerable.Range(24, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
            Assert.AreEqual("31st", 31.AsOrdinal());
            Assert.AreEqual("32nd", 32.AsOrdinal());
            Assert.AreEqual("33rd", 33.AsOrdinal());
            //then just jump to 100
            Assert.AreEqual("101st", 101.AsOrdinal());
            Assert.AreEqual("102nd", 102.AsOrdinal());
            Assert.AreEqual("103rd", 103.AsOrdinal());
            foreach (var integer in Enumerable.Range(104, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
            Assert.AreEqual("111th", 111.AsOrdinal());
            Assert.AreEqual("112th", 112.AsOrdinal());
            Assert.AreEqual("113th", 113.AsOrdinal());
            foreach (var integer in Enumerable.Range(114, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
            Assert.AreEqual("121st", 121.AsOrdinal());
            Assert.AreEqual("122nd", 122.AsOrdinal());
            Assert.AreEqual("123rd", 123.AsOrdinal());
            foreach (var integer in Enumerable.Range(124, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
            //then just jump to 1000
            Assert.AreEqual("1,001st", 1001.AsOrdinal());
            Assert.AreEqual("1,002nd", 1002.AsOrdinal());
            Assert.AreEqual("1,003rd", 1003.AsOrdinal());
            foreach (var integer in Enumerable.Range(1004, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
            Assert.AreEqual("1,011th", 1011.AsOrdinal());
            Assert.AreEqual("1,012th", 1012.AsOrdinal());
            Assert.AreEqual("1,013th", 1013.AsOrdinal());
            foreach (var integer in Enumerable.Range(1014, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
            Assert.AreEqual("1,021st", 1021.AsOrdinal());
            Assert.AreEqual("1,022nd", 1022.AsOrdinal());
            Assert.AreEqual("1,023rd", 1023.AsOrdinal());
            foreach (var integer in Enumerable.Range(1024, 6))
                Assert.AreEqual(String.Format("{0:n0}th", integer), integer.AsOrdinal());
        }
    }
