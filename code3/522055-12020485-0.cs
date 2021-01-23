        [TestMethod]
        public void Foo()
        {
            using (ShimsContext.Create())
            {
                ShimFile.ReadAllTextString = path => "test 123";
                var reverser = new TextReverser();
                const string expected = "321 tset";
                //Act
                var actual = reverser.ReverseSomeTextFromAFile(@"C:\fakefile.txt");
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }
