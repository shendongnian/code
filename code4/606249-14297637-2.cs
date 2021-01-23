    using System.Windows;
    class WPFMessageBoxService : IMessageBoxService
    {
        bool ShowMessage(string text, string caption, MessageType messageType)
        {
            // TODO: Choose MessageBoxButton and MessageBoxImage based on MessageType received
            MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
