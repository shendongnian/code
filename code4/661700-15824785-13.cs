    public static class MsgBox
    {
        private static DialogResult MessageBox(MessageViewModel messageViewModel, BottomPanelButtons buttons)
        {
            var viewModel = new MessageWindowViewModel(messageViewModel, buttons);
            var window = new MessageWindow(viewModel);
            window.ShowDialog();
            return viewModel.DialogResult;
        }
        /// <summary>
        /// Displays an informative message to the user.
        /// </summary>
        /// <param name="title">The message's title.</param>
        /// <param name="message">The message's body.</param>
        /// <returns>Returns <see cref="DialogResult.Ok"/> if user closes the window by clicking the Ok button.</returns>
        public static DialogResult Info(string title, string message)
        {
            return Info(title, message, string.Empty);
        }
        /// <summary>
        /// Displays an informative message to the user.
        /// </summary>
        /// <param name="title">The message's title.</param>
        /// <param name="message">The message's body.</param>
        /// <param name="details">The collapsible message's details.</param>
        /// <returns>Returns <see cref="DialogResult.Ok"/> if user closes the window by clicking the Ok button.</returns>
        public static DialogResult Info(string title, string message, string details)
        {
            var viewModel = new MessageViewModel(title, message, details, MessageIcons.Info);
            return MessageBox(viewModel, BottomPanelButtons.Ok);
        }
        /// <summary>
        /// Displays an error message to the user, with stack trace as message details.
        /// </summary>
        /// <param name="title">The message's title.</param>
        /// <param name="exception">The exception to report.</param>
        /// <returns>Returns <see cref="DialogResult.Ok"/> if user closes the window by clicking the Ok button.</returns>
        public static DialogResult Error(string title, Exception exception)
        {
            var viewModel = new MessageViewModel(title, exception.Message, exception.StackTrace, MessageIcons.Error);
            return MessageBox(viewModel, BottomPanelButtons.Ok);
        }
        ...
    }
