    public class MyForm : Form {
       public MyForm() { Initialize(); }
       protected void buttonClick(object sender, EventArgs e) {
           // Suppose we initialize a client on a click of a button
           Client client = new Client();
           // note: don't use () on the function here
           client.ReceivedFile += onReceivedFile;
           client.Connect();
       }
       private void onReceivedFile(object sender, ReceivedFileEventArgs args) {
           if (InvokeRequired) {
               // we need to make sure we are on the GUI thread
               Invoke(new Action<object, args>(onReceivedFile), sender, args);
               return;
           }
           // we are in the GUI thread, so we can show the SaveFileDialog
           using (SaveFileDialog dialog = new SaveFileDialog()) {
               args.FileName = dialog.FileName;
           }
       }
    }
