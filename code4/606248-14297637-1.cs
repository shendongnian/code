    class WPFMessageBoxService:IMessageBoxService
    {
      bool ShowMessage(string text, string caption, MessageType messageType)
      {
         System.Windows.MessageBox.Show(text,caption); // messageBoxIcon is created based on MessageType // Removed windows forms dependency.
      }
      
    }
