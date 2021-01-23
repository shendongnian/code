    // Arrange
    var canExecuteChanged = false;
    viewModel.FooCommand.CanExecuteChanged += 
        (sender, args) => canExecuteChanged = true;
    // Act
    viewModel.SomeRequiredProperty = new object();
    DispatcherTestHelper.ProcessWorkItems();
    // Assert
    Assert.That(canExecuteChanged, Is.True);
