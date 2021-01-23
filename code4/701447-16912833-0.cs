        [TestMethod]
        public void ShouldArrangeFutureCallToMethod()
        {
            // arrange CloseConnection for all future instances of Class2.
            // "new X()" is equivalent to using .IgnoreInstance()
            Mock.Arrange(() => new Class2().CloseConnection(Arg.AnyBool)).DoNothing();
            // act
            var c1 = new Class1();
            c1.Close();
            //success: didn't throw
        }
        public class Class1
        {
            private Class2 instanceOfClass2;
            public Class1()
            {
                instanceOfClass2 = new Class2();
            }
            public void Close()
            {
                // other code here
                instanceOfClass2.CloseConnection(true);
            }
        }
        public class Class2
        {
            public void CloseConnection(bool persist)
            {
                throw new NotImplementedException();
            }
        }
