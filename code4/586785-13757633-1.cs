        private void onPreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // In this case, we just say it always can be executed (only for a Paste command), but you can 
            // write some checks here
            if (e.Command == ApplicationCommands.Paste)
            {
                e.CanExecute = true;
                e.Handled = true;
            }
        }
        private void onPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // If it is a paste command..
            if (e.Command == ApplicationCommands.Paste)
            {
                // .. and the clipboard contains an image
                if (Clipboard.ContainsImage())
                {
                    // proccess it somehow
                    e.Handled = true;
                }
                
            }
        }
