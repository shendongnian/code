     public void notifyWindowToClose()
    {
        Messenger.Default.Send<NotificationMessage>(
            new NotificationMessage(this, "CloseWindowsBoundToMe")
        );
    }
