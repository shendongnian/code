    public class ViewModel
    {
        public AsyncCommand AsyncCommand { get; private set; }
        public bool Executed { get; private set; }
        public ViewModel()
        {
            Executed = false;
            AsyncCommand = new AsyncCommand(Execute);
        }
        private async Task Execute()
        {
            await(Task.Delay(1000));
            Executed = true;
        }
    }
