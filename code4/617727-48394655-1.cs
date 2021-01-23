    using System;
    using UtilityLib.APIDir;
    namespace UtilityLibTest
    {
       [TestClass]
       public class UnitTest_NewAPI
       {
           [TestMethod]
           public void TestNewAPI()
           {
              NewAPI tester = new NewAPI();
              bool someResult = tester.DoSomething();
           }
       }
    }
