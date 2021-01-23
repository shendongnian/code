    public class Form1 : Form
    {
        private void SomeEventHandler(object sender, EventArgs args)
        {
            Task.Run(()=>new PrintClass().DoWork())
                .ContinueWith(t => TboxPrint.AppendText(t.Result)
                    , CancellationToken.None
                    , TaskContinuationOptions.None
                    , TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
