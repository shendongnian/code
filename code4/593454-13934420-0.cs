    public class AsyncSaveTester : 'put yourclassIheritance Here'
    {
        private SaveFileDialog asyncSaveDialog;
        public SaveFileDialog AsyncSaveDialog
        {
            get { return asyncSaveDialog; }
            set { asyncSaveDialog = value; }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            asyncSaveDialog = new SaveFileDialog();
            //Write your code to Show the Dialog here
        }
        // where is the handler for your webservice call...find that and call the Save method from there
        private void Save(string fileToSave)
        {
            Stream fileStream = asyncSaveDialog.OpenFile();
            // If you choose to use Streaming, then you would write the code here to do the file Streaming from 
            // the web Service call
        }
    }
