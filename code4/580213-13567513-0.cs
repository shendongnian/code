        public ICommand BrowseFileFolderCommand
        {
            get
            {
                if (_browseFileFolderCommand == null)
                {
                    _browseFileFolderCommand = new RelayCommand(o =>
                        {
                            var messageViewModel = new MessageBoxViewModel("Add a Folder or File", "What do you wish to add, folder or file?", "Folder", "File");
                            var choice = new CustomMessageBox()
                            {
                                DataContext = messageViewModel
                            };
                            choice.ShowDialog();
                            if (messageViewModel.CustomMessageBoxDialogResult == DialogResult.Yes)
                            {
                                switch (messageViewModel.ChosenEntity)
                                {
                                    case SelectedAnswer.Answer1:
                                        // Get folder shizz
                                        break;
                                    case SelectedAnswer.Answer2:
                                        // Get file shizz
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }, null);
                }
                return _browseFileFolderCommand;
            }
        }
