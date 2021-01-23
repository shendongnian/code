    public class DialogService : IDialogService
    {
        private Stack<Window> windowStack = new Stack<Window>();
        public DialogService(Window root)
        {
            this.windowStack.Push(root);
        }
        public bool? ShowDialog(object dialogViewModel)
        {
            Window dialog = MapWindow(dialogViewModel); 
            dialog.DataContext = dialogViewModel;
            dialog.Owner = this.windowStack.Peek();
            this.windowStack.Push(dialog);
            bool? result;
            try
            {
                result = dialog.ShowDialog();
            }
            finally
            {
                this.windowStack.Pop();
            }
            return result;
        }
    }
