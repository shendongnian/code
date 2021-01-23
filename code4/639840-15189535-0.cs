        [Test]
        public void SumDynamics()
        {
            // note that we can specify as many ints as we like
            Assert.AreEqual(8, Sum(3, 5)); // test passes
            Assert.AreEqual(4, Sum(1, 1 , 1, 1)); // test passes
            Assert.AreEqual(3, Sum(3)); // test passes
        }
        // Meaningless example but it's purpose is only to show that you can use dynamic 
        // as a parameter, and that you also can combine it with the params type.
        public static dynamic Sum(params dynamic[] ints)
        {
            return ints.Sum(i => i);
        }
