        [TestMethod]
        public void TestMethod()
        {
            var table = new[] 
            {
                new{ Id = 1, Name = "Paul", Points = 10},
                new{ Id = 2, Name = "Ringo", Points = 2},
                new{ Id = 3, Name = "George", Points = 30},
                new{ Id = 4, Name = "John", Points = 5}
            };
            int position = table.OrderByDescending(x => x.Points).TakeWhile(x => x.Name != "Paul").Count() + 1;
            Assert.AreEqual(2, position);
        }
