    public class ExampleClass
    {
        private object _myContextInfo; //This can be multiple objects, or a single structured object or whatever you need.
        public void Main()
        {
            _myContextInfo = new object();//Set this to whatever you need
            var bw = new BackgroundWorker();
            bw.DoWork += DoSomethingAsync;
            bw.RunWorkerCompleted += TakeActionOnCompletion;
            bw.RunWorkerAsync();
            //Do whatever you want done in parallel to your other item here
        }
        private void DoSomethingAsync(object sender, DoWorkEventArgs e)
        {
            //Do whatever you need and use the class fields however you want;
        }
        private void TakeActionOnCompletion(object sender, RunWorkerCompletedEventArgs e)
        {
            //Use the results however you need and read/manipulte the class fields however you want;
        }
