     public partial class Form1 : Form
    {
        FileManagerClient client;
        public Form1()
        {
            InitializeComponent();
            Callback callback = new Callback();
            //Subscribe event for notification
            callback.OnDataReceivedEvent +=new Callback.OnDataReceived(callback_OnDataReceivedEvent);
            InstanceContext ctx = new InstanceContext(callback);
            client = new FileManagerClient(ctx);
        }
        private void callback_OnDataReceivedEvent(object sender, ListViewItem item)
        {
            //Add item here
        }
    }
    class Callback : IFileManagerCallback
    {
        private delegate void OnDataReceived(object sender, ListViewItem item);
        private OnDataReceived _dataReceivedHandler = null;
        public event OnDataReceived OnDataReceivedEvent {
            add { _dataReceivedHandler += value; }
            remove { _dataReceivedHandler -= value; }
        }
        public void Folder(_Folder folder)
        {
            ListViewItem item = new ListViewItem();
            item.Text = folder.Name;
            item.ToolTipText = folder.Path;
            item.Tag = item.ImageIndex;
            item.Name = item.Text;
            RaiseEvents(item);
            //Add item to listView1
        }
        public void File(_File file)
        {
            ListViewItem item = new ListViewItem();
            item.Text = file.Name;
            item.ToolTipText = file.Path;
            item.Tag = item.ImageIndex;
            item.Name = item.Text;
            RaiseEvents(item);
            //Add item to listView1
        }
        private void RaiseEvents(ListViewItem item)
        {
            if (_dataReceivedHandler != null)
            {
                _dataReceivedHandler(this, item);
            }
        }
    }
