        [Test]
        public void Passing_StringArray_Into_StringFormat()
        {
            var replacements = new string[]
                {
                    "MIKE",
                    "Los Angeles"
                };
            string sample = string.Format("My name is {0}, I am living in {1} ...", replacements);
            Assert.AreEqual("My name is MIKE, I am living in Los Angeles ...", sample);
        }
