    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MarqueeForm.DoWithProgress("Doing login", Login);
        }
        private static void Login()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }
    public class MarqueeForm : Form
    {
        private Label label;
        public MarqueeForm()
        {
            var progressBar = new ProgressBar
                              {
                                  Style = ProgressBarStyle.Marquee, 
                                  Top = 20, 
                                  Size = new Size(300, 15)
                              };
            Controls.Add(progressBar);
            label = new Label();
            Controls.Add(label);
        }
        public static void DoWithProgress(string title, Action action)
        {
            var form = new MarqueeForm
                       {
                           Size = new Size(310, 50),
                           StartPosition = FormStartPosition.CenterParent,
                           FormBorderStyle = FormBorderStyle.FixedDialog,
                           ControlBox = false,
                           label = { Text = title }
                       };
            form.Load += (sender, args) =>
                Task.Factory.StartNew(action)
                    .ContinueWith(t => ((Form)sender).Close(),
                        TaskScheduler.FromCurrentSynchronizationContext());
            form.Show();
        }
    }
