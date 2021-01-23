        [TestMethod]
        public void SpecificGeneric()
        {
            bool hitException = false;
            try
            {
                throw new WebFaultException<string>();
            }
            catch(WebFaultException<string> e)
            {
                hitException = true;
            }
            Assert.IsTrue(hitException);
        }
        [TestMethod]
        public void AnyGeneric()
        {
            bool hitException = false;
            try
            {
                throw new WebFaultException<int>();
            }
            catch (WebFaultException<string> e)
            {
                hitException = false;
            }
            catch (WebFaultException e)
            {
                hitException = true;
            }
            Assert.IsTrue(hitException);
        }
