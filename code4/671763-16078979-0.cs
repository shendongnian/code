        [Test]
        public void ATest()
        {
            const string TestValue = "a:b,c";
            string valueForColumnA = new Regex(@"[a-z]+(?=\:)").Match(TestValue).Value;
            string setForColumnB = new Regex(@"(?<=\:)[a-z]+(,[a-z]+)*").Match(TestValue).Value;
            var target = setForColumnB.Split(',')
                .Select(item => new MyClass { Column1 = valueForColumnA, Column2 = item })
                .ToList();
            Assert.AreEqual(target[0].Column1, "a");
            Assert.AreEqual(target[0].Column2, "b");
            Assert.AreEqual(target[1].Column1, "a");
            Assert.AreEqual(target[1].Column2, "c");
        }
