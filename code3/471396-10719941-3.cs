    using System.Windows;
    using System.Windows.Input;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Media;
    using System;
    
    namespace BackgroundWorkerExample
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
    
    
            void _asyncSpeakerThread_DoWork(object sender, DoWorkEventArgs e)
            {
                // Change color of text to Red to indicate Start of operation
                this.Dispatcher.BeginInvoke(new Action(() =>  { textBox1.Foreground = Brushes.Red; }));
    
                string text = e.Argument as string;
                //voice.Speak(text, SpeechVoiceSpeakFlags.SVSFDefault); // Lengthy operation 
                Thread.Sleep(1000); // Simulate lengthy operation
    
                // Change color of text to Black to indicate End of operation
                this.Dispatcher.BeginInvoke(new Action(() => { textBox1.Foreground = Brushes.Black; }));
            }
    
            private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                BackgroundWorker bw = new BackgroundWorker();
    
                bw.DoWork += new DoWorkEventHandler(_asyncSpeakerThread_DoWork);
                string workerArgument = textBox1.Text;
                bw.RunWorkerAsync(workerArgument);
            }
        }
    }
