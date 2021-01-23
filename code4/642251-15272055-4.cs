        [TestMethod]
        public void SubjectTestWithSubjectEquals()
        {
            Assert.IsTrue(Subject.Equals(new Subject(1), new Subject(1)));
            Assert.IsTrue(new Subject(1).Equals(new Subject(1)));
            Assert.IsFalse(Subject.Equals(new Subject(1), new Subject(2)));
            Assert.IsFalse(new Subject(1).Equals(new Subject(2)));
        }
