    using System.Runtime.CompilerServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [assembly: InternalsVisibleTo( "MyDataLayerAssembly" )]
    namespace MyUnitTestProject.DataTests
    {
    
       [TestClass]
       public class ContactTests
       {
          ...
