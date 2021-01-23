        [Test]
        public void Collates_Blah_As_Blah()
        {
            Assert.False(SINGLETON.Collection.Any());
            for (int i = 0; i < 2; i++)
                Assert.That(PROCESS(ValidRequest) == Status.Success);
            try
            {
                Assert.AreEqual(1, SINGLETON.Collection.Count);
            }
            finally
            {
                SINGLETON.Collection.Clear();
            }
        }
