    public class FooViewModel
    {
        public FooViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;
        }
        public IDialogService DialogService { get; set; }
        public DelegateCommand DeleteBarCommand
        {
            get
            {
                return new DelegateCommand(DeleteBar);
            }
        }
        public void DeleteBar()
        {
            var delete = DialogService.AskYesNoQuestion("Are you sure you want to delete bar?", "Delete Bar");
            if (delete)
            {
                Bar.Delete();
            }
        }
        ...
    }
