    using System;
    using System.Messaging;
    using System.Windows.Forms;
    
    namespace MessageTo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                #region Create My Own Queue 
    
                MessageQueue messageQueue = null;
                if (MessageQueue.Exists(@".\Private$\TestApp1"))
                {
                    messageQueue = new MessageQueue(@".\Private$\TestApp1");
                    messageQueue.Label = "MyQueueLabel";
                }
                else
                {
                    // Create the Queue
                    MessageQueue.Create(@".\Private$\TestApp1");
                    messageQueue = new MessageQueue(@".\Private$\TestApp1");
                    messageQueue.Label = "MyQueueLabel";
                }
    
                #endregion
    
                MyMessage.MyMessage m1 = new MyMessage.MyMessage();
                m1.BornPoint = DateTime.Now;
                m1.LifeInterval = TimeSpan.FromSeconds(5);
                m1.Text = "Command Start: " + DateTime.Now.ToString();
    
                messageQueue.Send(m1);
            }
        }
    }
