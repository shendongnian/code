    public class Item
    {
        public void Update()
        {
            Save();
        }
    
        private void Save()
        {
            Validate();
            /// Save something
        }
    
        private void Validate()
        {
            /// Validate something
        }
    }
    
    [Fact]
    public void EnsureNestedPrivateMethodsAreCalled()
    {
        // Arrange
        Item item = Mock.Create<Item>();
        Mock.Arrange(() => item.Update()).CallOriginal().MustBeCalled();
        Mock.NonPublic.Arrange(item, "Save").CallOriginal().MustBeCalled();
        Mock.NonPublic.Arrange(item, "Validate").DoNothing().MustBeCalled();
    
        // Act
        item.Update();
    
        // Assert
        Mock.Assert(item);
    }
