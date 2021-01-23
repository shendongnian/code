    using System.Reactive.Linq;
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            private System.Windows.Forms.ProgressBar curProgressBar;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                CustomProcess theProcess = new CustomProcess();
                var x = theProcess.Process().ToObservable();
                curProgressBar.Maximum = 10;
                x.Subscribe((i) =>
                {
                    curProgressBar.Value = i;
                });
            }
        }
        class CustomProcess
        {
            public IEnumerable<int> Process()
            {
                for (int i = 0; i <= 10; i++)
                {
                    Task ProcessATask = Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(1000); // simulating a process
                        }
                     );
                    yield return i;
                }
            }
        }
    }
