    [Test]
    public void SimpleTestUsingMessageBox()
    {
     // Arrange
     Isolate.WhenCalled(()=>MessageBox.Show(String.Empty)).WillReturn(DialogResult.OK);
     
     // Act
     MessageBox.Show("This is a message");
     
     // Assert
     Isolate.Verify.WasCalledWithExactArguments(()=>MessageBox.Show("This is a message"));
    }
