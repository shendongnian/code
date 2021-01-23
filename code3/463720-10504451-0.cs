        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private Process cmd;
            private bool scrollAtBottom = false;
            public MainWindow()
            {
                InitializeComponent();
    
                Closed+=new EventHandler(MainWindow_Closed);
                textBlock1.Text = "";
    
                textBox1.Focus();
            }
    
            private void button1_Click_1(object sender, RoutedEventArgs e)
            {
                if (cmd == null || cmd.HasExited)
                {
                    cmd = new Process();
                    cmd.StartInfo.CreateNoWindow = false;
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.UseShellExecute = false;
    
                    cmd.OutputDataReceived += new DataReceivedEventHandler(cmd_OutputDataReceived);
    
                    cmd.Start();
                    cmd.BeginOutputReadLine();
                }
    
                cmd.StandardInput.WriteLine(textBox1.Text);
    
                textBox1.Text = "";
            }
    
            private void cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                textBlock1.Dispatcher.Invoke(new Action(() =>
                {
                    textBlock1.Text += e.Data + Environment.NewLine;
                    scrollViewer1.ScrollToEnd();
                }));
            }
    
            private void MainWindow_Closed(object sender, EventArgs e)
            {
                if (cmd != null && !cmd.HasExited)
                {
                    //exit nicely
                    cmd.StandardInput.WriteLine("exit");
                    if (!cmd.HasExited)
                    {
                        //exit not nicely
                        cmd.Kill();
                    }
                }
            }
        }
