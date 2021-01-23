        [Test, ExpectedException(typeof(RuntimeBinderException))]
        public void AssignDynamicIntAndStoreAsString()
        {
            dynamic i = 5;
            string astring = i; // this will compile, but will throw a runtime exception
        }
