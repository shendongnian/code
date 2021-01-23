    using System.Collections.ObjectModel;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace ExtensionMethods
    {
        [TestClass]
        public class ObservableCollectionExtensionMethodsTest
        {
            [TestMethod]
            public void ReplaceTest()
            {
                // Arrange
                var old = new ObservableCollection<string> { "1"};
                var @new = new ObservableCollection<string> {"2"};
    
                // Act
                old.Replace(@new);
    
                // Assert
                Assert.AreEqual("2", old.First());
            }
        }
    }
