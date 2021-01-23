    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CancellationTokenSource _cancel;
        private object _loadLock = new object();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (_loadLock)
            {
                handleCancellation();
                var loader = new Task((chosenFileItemInListbox) =>
                    {
                        Thread.Sleep(1000);
                        LoadFile(chosenFileItemInListbox);
                    }, listBox1.SelectedItem, _cancel.Token);
            }
        }
        private bool handleCancellation()
        {
            bool cancelled = false;
            lock (_loadLock)
            {
                if (_cancel != null)
                {
                    if (!_cancel.IsCancellationRequested)
                    {
                        _cancel.Cancel();
                        cancelled = true;
                    }
                    _cancel = null;
                } 
            }
            return cancelled;
        }
        private void LoadFile(object chosenFileItemInListbox)
        {
            if (handleCancellation())
            {
                return;
            }
        }
    }
