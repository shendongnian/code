    // Added the form's class declaration to highlight separation of thread code into a separate class, but may not be exactly the same as yours depending on naming
    public class Form1 : Form
    {
        private readonly DataRetriever _dataRetriever;
        private void form_main_Shown(object sender, EventArgs e)
        {            
            // Set the loading text.
            list_selection.Items.Add(ListHelpers.LoadingItem());
            // Create the DataRetriever, and provide it with a delegate to DisplayList for returning data
            _dataRetriever = new DataRetriever(DisplayList);
            // Start retrieving data on a separate thread...
            _dataRetriever.GetData();
        }
        private void DisplayList(List<ListBoxItem> itemList)
        {
            if (InvokeRequired)
            {
                // Ensure the update occurs on the UI thread
                Invoke((Action)(() => DisplayList(itemList)));
                return;
            }
            // Display each result
            list_selection.Items.Clear();
            foreach (var item in itemList)
            {
                list_selection.Items.Add(item);
            }
        }
    }
    // Separate class to hold thread code
    public class DataRetriever
    {
        public delegate void UpdateCallbackDelegate(List<ListBoxItem> itemList);
        private readonly UpdateCallbackDelegate _updateCallback;
        public DataRetriever(UpdateCallbackDelegate updateCallback)
        {
            _updateCallback = updateCallback;
        }
        public void GetData()
        {
            var thread = new Thread(GetInvoicingData)
            {
                IsBackground = true
            };
            thread.Start();
        }
        private void GetInvoicingData()
        {
            // Not sure whether "DAC" is a static class, if it needs to be constructed
            // in the DataRetriever's constructor, or passed to it as a parameter
            _updateCallback(DAC.GetInvoicingAccounts());
        }
    }
