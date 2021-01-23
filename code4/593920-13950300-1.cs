    using System.Reactive.Linq;
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            //private System.Windows.Forms.ProgressBar curProgressBar;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                CustomProcess theProcess = new CustomProcess();
                var x = Observable.FromEventPattern(theProcess, "TaskCompleted");
                curProgressBar.Maximum = 3;
                x.Subscribe((a) =>
                {
                    curProgressBar.Value = ((CustomProcess)a.Sender).Counter-1;
                });
                theProcess.Process();
            }
        }
        class CustomProcess
        {
            public int Counter { get; set; }
            public event EventHandler TaskCompleted = OnTaskCompleted;
            private static void OnTaskCompleted(object sender, EventArgs e)
            {
                ((CustomProcess)sender).Counter++;
            }
            public void Process()
            {
                for (int i = 0; i <= 3; i++)
                {
                    Task ProcessATask = Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(1000); // simulating a process
                        }
                     );
                    var awaiter = ProcessATask.GetAwaiter();
                    awaiter.OnCompleted(() =>
                    {
                        TaskCompleted(this, null);
                    });
                }
            }
        }
    }
