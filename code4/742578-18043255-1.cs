    class MyMessageBox : Xceed.Wpf.Toolkit.MessageBox
    {
        public static MessageBoxResult Show(object dataContext)
        {
            var messageBox = new MyMessageBox();
            messageBox.InitializeMessageBox(null, null, "Hello", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            messageBox.SetBinding(MyMessageBox.TextProperty, new Binding
            {
                Path = new PropertyPath("Text"),
                Source = dataContext
            });
            messageBox.ShowDialog();
            return messageBox.MessageBoxResult;
        }
    }
