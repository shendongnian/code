    public class MyViewModel : NotificationObject
    {
        // Dependencies
        private readonly IService _doSomethingService;
        private readonly IDelegateWorker _delegateWorker;
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                if (_IsBusy != value)
                {
                    _IsBusy = value;
                    RaisePropertyChanged(() => IsBusy);
                }
            }
        }
        public ICommand DisplayInputDialogCommand { get; private set; }
        public InteractionRequest<Notification> ErrorDialogInteractionRequest { get; private set; }
        public InteractionRequest<Confirmation> InputDialogInteractionRequest { get; private set; }
        // ctor
        public MyViewModel(IService service, IDelegateWorker delegateWorker)
        {
            _doSomethingService = service;
            _delegateWorker = delegateWorker;
            DisplayInputDialogCommand = new DelegateCommand(DisplayInputDialog);
            ErrorDialogInteractionRequest = new InteractionRequest<Notification>();
            InputDialogInteractionRequest = new InteractionRequest<Confirmation>();
        }
        private void DisplayInputDialog()
        {
            InputDialogInteractionRequest.Raise(
                new Confirmation()
                {
                    Title = "Please provide input...",
                    Content = new DialogContentViewModel()
                },
                ProcessInput
            );
        }
        private void ProcessInput(Confirmation context)
        {
            if (context.Confirmed)
            {
                IsBusy = true;
                /* BackgroundWorker now abstracted behind IDelegateWorker interface */
                _delegateWorker.Start<object, TaskResult<object>>(
                        ProcessInput_onStart,
                        ProcessInput_onComplete,
                        null
                    );
            }
        }
        private TaskResult<object> ProcessInput_onStart(object parm)
        {
            TaskResult<object> result = new TaskResult<object>();
            try
            {
                result.Result = _doSomethingService.DoSomething();
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }
            return result;
        }
        private void ProcessInput_onComplete(TaskResult<object> tr)
        {
            IsBusy = false;
            if (tr.Error != null)
            {
                ErrorDialogInteractionRequest.Raise(
                    new Confirmation()
                    {
                        Title = "Error",
                        Content = tr.Error.Message
                    }
                );
            }
        }
        // Helper Class
        public class TaskResult<T>
        {
            public Exception Error;
            public T Result;
        }
    }
