    // Create an EventArgs based class for the data
    public class DataDownloadEventArgs : EventArgs
    {
        public string Data { get; set; }
        
        public DataDownloadEventArgs(string data)
        {
            Data = data;
        }
    }
    public partial class Form1 : Form
    {
    
        // Event handler when data is downloaded
        public event EventHandler<DataDownloadEventArgs> DataDownloaded;
        // Virtual method to raise event to observers
        protected virtual void OnDataDownloaded(DataDownloadEventArgs e)
        {
            var handler = DataDownloaded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        // Form constructor
        public Form1()
        {
            InitializeComponent();
            // Add handler for the download event
            DataDownloaded += new EventHandler<DataDownloadEventArgs>(DisplayData);
        }
        
        // Serial port receive event
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // snip...
            switch (text[0])
            {
                case '?': MemLabelUpdate(); break;
                case '>': WriteConfig(text); break;
                case '=': SealTest(text); break;
                case '<': CurrentNumber(text); break;
                default:
                    DataDownload(text);
                    OnDataDownloaded(new DataDownloadEventArgs(text));
                    break;
            }
            // snip...
        }
        
        // Change btnDisplayData_Click to the following:
        private void DisplayData(object sender, DataDownloadEventArgs e)
        {
            // insert remaining code from btnDisplayData_Click
        }
    }
