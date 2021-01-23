    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Threading;
    public partial class Test : Form
	{
		Thread thread;
		public Test()
		{
			InitializeComponent();
			
		}
        void Button1_Click(object sender, EventArgs e)
		{
            thread = new Thread(new ThreadStart(StartThread));
			thread.Start();
		}
        private void StartThread()
		{
			for(int i =0;i<1000000;i++)
			{
				Thread.Sleep(1000);
				Label1.Invoke((MethodInvoker)(() => Label1.Text = i.ToString())); 
                //See the more information section, I will post a link about this.
			}
		}
        void Label1_Click(object sender, EventArgs e)
		{
			thread.Abort();
		}
    }
