    public class MessageWindowViewModel : ViewModelBase, IHasBottomPanel
    {
        /// <summary>
        /// Gets/sets ViewModel for the message window's content.
        /// </summary>
        public MessageViewModel ContentViewModel { get { return _messageViewModel; } }
        private MessageViewModel _messageViewModel;
        public MessageWindowViewModel()
            : this(new MessageViewModel())
        { }
        public MessageWindowViewModel(MessageViewModel viewModel)
            : this(viewModel, BottomPanelButtons.Ok)
        { }
        public MessageWindowViewModel(MessageViewModel messageViewModel, BottomPanelButtons buttons)
        {
            _messageViewModel = messageViewModel;
            // "this" is passed as the BottomPanelViewModel's IHasBottomPanel parameter:
            _bottomPanelViewModel = new BottomPanelViewModel(buttons, this);
        }
        ...
        public void ExecuteOkCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = DialogResult.Ok;
            if (WindowClosing != null) WindowClosing(this, EventArgs.Empty);
        }
        public void CanExecuteOkCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _messageViewModel.ShowProgressControls
                ? _messageViewModel.ProgressValue == _messageViewModel.MaxProgressValue
                : true;
        }
