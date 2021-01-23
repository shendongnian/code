        [TestMethod]
        public void CallingGenericMethod()
        {
            Assert.IsTrue(GenericExceptionMethod<int>());
        }
        private bool GenericExceptionMethod<T>()
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
            catch (WebFaultException<T> e)
            {
                hitException = true;
            }
            return hitException;
        }
