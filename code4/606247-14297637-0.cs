    class WPFMessageBoxService:IMessageBoxService
    {
      bool ShowMessage(string text, string caption, MessageType messageType)
      {
         System.Windows.Forms.MessageBox.Show(text,caption, MessageBoxButtons.OKCancel, messageBoxIcon); // messageBoxIcon is created based on MessageType
      }
      
    }
