    // Arrange
    var canExecuteChanged = false;
    viewModel.FooCommand.CanExecuteChanged += 
        (sender, args) => canExecuteChanged = true;
    // Act
    viewModel.SomeRequiredProperty = new object();
    DispatcherTestHelper.ProcessWorkItems(DispatcherPriority.Background);
    // Assert
    Assert.That(canExecuteChanged, Is.True);
