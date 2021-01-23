        [Test]
        public void Should_be_exactly_20_years_old()
        {
            var now = DateTime.Now;
            var age = new Age(now.AddYears(-20), now);
            Assert.That(age, Has.Property("Years").EqualTo(20)
                .And.Property("Months").EqualTo(0)
                .And.Property("Days").EqualTo(0));
        }
