    namespace WinFormsPleaseWaitExample
    {
    //You don't need these 2 lines if you have .Net 3 or later
    public delegate void Action(); 
    public delegate TResult Func<TResult>();
    //
    public partial class Form1 : Form
    {
        private readonly Form pleaseWaitForm;
        public Form1()
        {
            InitializeComponent();
            pleaseWaitForm = new PleaseWaitForm {Owner = this};
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var result= DoWithPleaseWait(delegate { return SomeBusinessLayerClass.ADataRetrieval("boo"); });
            MessageBox.Show(result.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DoWithPleaseWait(delegate { SomeBusinessLayerClass.ADataOperation("boo"); });
        }
        public void DoWithPleaseWait(Action action)
        {
            pleaseWaitForm.Show();
            action.DynamicInvoke();
            pleaseWaitForm.Hide();
        }
        public TResult DoWithPleaseWait<TResult>(Func<TResult> func)
        {
            pleaseWaitForm.Show();
            TResult result = (TResult)func.DynamicInvoke();
            pleaseWaitForm.Hide();
            return result;
        }
    }
    public class SomeBusinessLayerClass
    {
        public static void ADataOperation(string someInput)
        {
            //Do something that might take several seconds...
            Thread.Sleep(3000);
        }
        public static object ADataRetrieval(string someInput)
        {
            //Do something that might take several seconds...
            Thread.Sleep(3000);
            return someInput + " returned";
        }
    }
    }
