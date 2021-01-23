    using NUnit.Framework;
    using System.Diagnostics.Contracts;
    
    namespace Tests
    {
        [TestFixture]
        class EnsureResult_nunit
        {
            [Test]
            public void testA()
            {
                var z = str1();
                var y = str2();
            }
    
            [Test, ExpectedException]
            public void testB()
            {
                var z = str3();
            }
    
            [Test, ExpectedException]
            public void testC()
            {
                var y = str4();
            }
    
    
            public string str1() 
            {
                Contract.Ensures(Contract.Result<Object>() != null);
                return "";
            }
    
            public string str2()
            {
                Contract.Ensures(Contract.Result<Object>() == null);
                return null;
            }
    
            public string str3()
            {
                Contract.Ensures(Contract.Result<Object>() == null);
                return "";
            }
    
            public string str4()
            {
                Contract.Ensures(Contract.Result<Object>() == null);
                return "";
            }
        }
    }
