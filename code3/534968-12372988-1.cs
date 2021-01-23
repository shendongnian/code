            [TestMethod]
            public void Queue()
            {
                var queue = new Queue<int>(new[]{1,2,3,4});
                queue = queue.SetFirstTo(9);
                Assert.AreEqual(queue.Peek(),9);
            }
