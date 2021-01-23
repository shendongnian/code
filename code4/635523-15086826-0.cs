    namespace WindowsFormsApplication1
    {
      using System;
      using System.Threading;
      using System.Windows.Forms;
      public partial class Form1 : Form
      {
        private Thread thread;
        public Form1()
        {
          this.InitializeComponent();
          this.thread = new Thread(this.WorkerThread);
        }
    
        private void WorkerThread(object sender)
        {
          Thread.Sleep(1000);
          while (true)
          {
            Thread.Sleep(25);
            this.SetText("from thread");
        
            Thread.Sleep(500);
          }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          this.thread.Abort();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          this.thread.Start();
        }
        /// <summary>
        /// This is a callback for the SetText Method.
        /// </summary>
        /// <param name="text">The text.</param>
        private delegate void SetTextCallback(string text);
        /// <summary>
        /// This sets a text. 
        /// It's thread safe, you can call this function from any thread. 
        /// If it's not called from the UI-thread, it will invoke itself
        /// on the UI thread.
        /// </summary>
        /// <param name="text">The text.</param>
        private void SetText(string text)
        {
          if (this.InvokeRequired)
          {
            this.Invoke(new SetTextCallback(this.SetText), text);
          }
          else
          {
            this.textBox1.Text = text;  
          }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
          this.SetText("from button");
        }
      }
    }
