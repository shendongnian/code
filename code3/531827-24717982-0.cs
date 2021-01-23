    public void UpdateExchangeEmail(string _ID, bool _isRead)
    {
      EmailMessage message = EmailMessage.Bind(ExchService, _ID);
      message.Load(); // Do this first.
      message.IsRead = _isRead;
      message.Update(ConflictResolutionMode.NeverOverwrite);
    }
