       `public void ReadByIdTestHelper<ObjectType>()
        {
            string schema = "dbo";
            long id = 1;
            Sol.Movie movie = new Movie();
            ObjectType actual;
            actual = Sol.Data.Object.ReadById<ObjectType>(schema, id);
            Assert.AreEqual((actual is ObjectType), true);
        }
        [TestMethod()]
        public void ReadByIdTest()
        {
            ReadByIdTestHelper<Sol.Movie>();
        }`
