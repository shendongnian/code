       [TestMethod]
        public void RemoveCharacters()
        {
            String testObj = "a \a b \b c \f d \n e \r f \t g \v h";
            Assert.AreEqual(@"abcdefgh", testObj.RemoveCategories(Strings.WhiteSpaceCategories()));
        }
    
        [TestMethod]
        public void KeepValidCharacters()
        {
            String testObj = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`12334567890-=~!@#$%^&*()_+[]\{}|;':,./<>?"  + "\"";
            Assert.AreEqual(@"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`12334567890-=~!@#$%^&*()_+[]\{}|;':,./<>?" + "\"", testObj.RemoveCategories(Strings.WhiteSpaceCategories()));
        }
