        /// <summary>
        ///A test for MapProperties
        ///</summary>
        public void MapPropertiesTestHelper<S, T>(S source, T target1, bool failIfNotMatched)
        {
            Cake.Common.Mapper<S, T> target = new Cake.Common.Mapper<S, T>();
            target.MapProperties(source, target1, failIfNotMatched);
        }
        [TestMethod()]
        public void MapPropertiesTest()
        {
            var source = new Source {
                OneTwo = 10,
                ThreeFour = "foo"
            };
            var target = new Target {
                OneTwo = 10,
                ThreeFour = "bar"
            };
            MapPropertiesTestHelper<Source, Target>(source, target, true);
            Assert.AreEqual(source.OneTwo, target.OneTwo);
            Assert.AreEqual(source.ThreeFour, target.ThreeFour);
            Assert.AreEqual(source.five_six, target.FiveSix);
        }
        public class Source
        {
            public int OneTwo { get; set; }
            public string ThreeFour { get; set; }
            public bool five_six { get; set; }
        }
        public class Target
        {
            public int OneTwo { get; set; }
            public string ThreeFour { get; set; }
            public bool FiveSix { get; set; }
        }
