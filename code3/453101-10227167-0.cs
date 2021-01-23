        /// <summary>
        /// A method to ask a confirmation question.
        /// </summary>
        /// <param name="messageText">The text to you the user.</param>
        /// <param name="showAreYouSureText">Optional Parameter which determines whether to prefix the message 
        /// text with "Are you sure you want to {0}?".</param>
        /// <returns>True if the user selected "Yes", otherwise false.</returns>
        public Boolean Confirm(String messageText, Boolean? showAreYouSureText = false)
        {
            String message;
            if (showAreYouSureText.HasValue && showAreYouSureText.Value)
                message = String.Format(Resources.AreYouSureMessage, messageText);
            else
                message = messageText;
            return DialogService.ShowMessageBox(this, message, MessageBoxType.Question) == MessageBoxResult.Yes;
        }
