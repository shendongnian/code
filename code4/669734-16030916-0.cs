    Messenger.Default.Register<ErrorMessage>(this, message =>
        {
            CustomMessageBox.Show(message.Message, message.Details, 
                                  MessageBoxButton.OK, MessageBoxImage.Error);
        }
