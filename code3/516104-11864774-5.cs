        [TestFixture]
        class graphloadingSpex
        {
            String[] lines = new String[] {
            "2,3,4",
            "1",
            "1,4",
            "1,3"
            };
            [Test]
            public void ShouldShowConnectionsAfterLoading()
            {
                Graph tested = new Graph(lines);
                Assert.AreEqual(new String[] { "2", "3", "4" }, tested["1"].GetConnextions());
                Assert.AreEqual(new String[] { "1"}, tested["2"].GetConnextions());
                Assert.AreEqual(new String[] { "1", "4" }, tested["3"].GetConnextions());
                Assert.AreEqual(new String[] { "1", "3" }, tested["4"].GetConnextions());
            }
        }
