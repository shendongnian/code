    using System.Security.Principal;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    namespace MockingIdentitySample.Test
    {
     [TestClass]
     public class UnitTest1
    {
        [TestInitialize]
        public void TestInitialize()
        {
            SetupMockedPrincipalAndIdentity(true, true, "John Doe"); 
        }
        private void SetupMockedPrincipalAndIdentity(bool autoSetPrincipal, bool isAuthenticated, string identityName)
        {
            var mockedPrincipal = new Mock<IPrincipal>();
            var mockedIdentity = new Mock<IIdentity>();
            mockedIdentity.Setup(m => m.Name).Returns(identityName);
            mockedIdentity.Setup(m => m.IsAuthenticated).Returns(isAuthenticated); 
            mockedPrincipal.Setup(p => p.Identity).Returns(mockedIdentity.Object);
         
            if (autoSetPrincipal)
             Thread.CurrentPrincipal = mockedPrincipal.Object;
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Thread.CurrentPrincipal.Identity.Name, "John Doe");
            Assert.IsTrue(Thread.CurrentPrincipal.Identity.IsAuthenticated); 
        }
       }
      }
