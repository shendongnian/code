        [Test]
        [Category("Slow")]
        public void IsValidLogFileName_nullFileName_ThrowsExcpetion()
        {
            // the exception we expect thrown from the IsValidFileName method
            var ex = Assert.Throws<ArgumentNullException>(() => a.IsValidLogFileName(""));
            // now we can test the exception itself
            Assert.That(ex.Message == "Blah");
        }
