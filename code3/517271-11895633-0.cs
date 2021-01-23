    public class ErrorMessage : DialogMessage
    {
        // See MvvmLight docs for more details, I've omitted constructor(s)
        /// <summary>
        /// Registers the specified recipient.
        /// </summary>
        /// <param name="recipient">The recipient of the message.</param>
        /// <param name="action">The action to perform when a message is sent.</param>
        public static void Register(object recipient, Action<ErrorMessage> action)
        {
            Messenger.Default.Register<ErrorMessage>(recipient, action);
        }
        /// <summary>
        /// Sends error dialog message to all registered recipients.
        /// </summary>
        public void Send()
        {
            Messenger.Default.Send<ErrorMessage>(this);
        }
     }
    public class SomeViewModel : ViewModelBase
    {
        public void SendErrorMessage(string message)
        {
            var errorMessage = new ErrorMessage(message);
            errorMessage.Send(); 
            // Or in your case, when the background worker is completed.          
        }
    }
