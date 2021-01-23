        [Test]
        public void DetectsMinusThreeAndTwo()
        {
            RepeatingDigitsDetector target = new RepeatingDigitsDetector();
            int[] source = new int[] { -4, -3, -3, -2, -1, 0, 1, 2, 2, 3, 4 };
            int[] expected = new int[] { -3, -2 };
            int[] actual = target.GetRepeats(source);
            Assert.AreEqual(expected.Length, actual.Length, "checking lengths");
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], "checking element {0}", i);
            }
        }
