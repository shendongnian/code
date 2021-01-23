    public partial class Form1 : Form
    {
        private IDisposable currentTimeout;
        public Form1()
        {
            InitializeComponent();
        }
        private void EndpointBox_KeyUp(object sender, KeyEventArgs e)
        {
            IDisposable timeout = TimerHelper.SetTimeout(() => TestHTTP200(EndpointBox.Text), 750);
            if (this.currentTimeout != null)
            {
                this.currentTimeout.Dispose();
                this.currentTimeout = timeout;
            }
        }
        private void TestHTTP200(string text)
        {
            //...
        }
    }
    public class TimerHelper
    {
        public static IDisposable SetTimeout(Action method, int delayInMilliseconds)
        {
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);
            timer.Elapsed += (source, e) =>
            {
                method();
            };
            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Start();
            // Returns a stop handle which can be used for stopping
            // the timer, if required
            return timer as IDisposable;
        }
    }
