        [Test]
        public void split()
        {
            string text = "the dog :is very# cute"  ;
            // how can i grab only the words:"is very" using the (: #) chars. 
            var actual = text.Split(new [] {':', '#'});
            Assert.AreEqual("is very", actual[1]);
        }
