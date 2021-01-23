    [Test]
    public void Convert_CreatesNewNotification()
    {
        var fixture = new Fixture();
        var args = fixture.CreateAnonymous<NotificationEventArgs>();
        var converter = new NotificationEventArgsConverter();
      
        var actualResult = converter.Convert(args);
       // Assert
    }
        
