    [Testclass]
    public class Tests
    {        
        [TestMethod]
        public void TestAddition()
        {
            AddItem();
            // Assert addition           
        }   
        [TestMethod]
        public void TestRemoval()
        {
           AddItem();
           // Remove item
           // Assert removal
        } 
        
        private void AddItem()
        {
           // Add item           
        }
    }
