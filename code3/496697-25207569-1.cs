    [TestMethod]
            public void Dice_Tests()
            {
                int[] cOut = new int[] { 6, 21, 56, 126 };
                for(int i = 1; i<=4; i++)
                {
                    var c = this.GetDiceCombinations(i);
                    Assert.AreEqual(cOut[i - 1], c.Length);
                }
            }
