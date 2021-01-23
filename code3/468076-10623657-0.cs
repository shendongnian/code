    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        
        public partial class Form1 : Form
        {
            Semaphore semaphore = new Semaphore(0, 3);
            public Form1()
            {
                InitializeComponent();
                myDelegate = new ChangeBack(ChangeBackMethod); 
            }
            
             private void frmMain_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                ListViewItem lvi = new ListViewItem(new string[] { i.ToString(), "Ready", "0" });
                lvItems.Items.Add(lvi);
            }
        }        
    
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            semaphore.Release(3);
    
            for (int i = 0; i < lvItems.Items.Count; i++)
            {
                WorkerThread(i);
            }
        }
    
        private Thread WorkerThread(int startNum)
        {
            Thread t = new Thread(new ParameterizedThreadStart(WorkerProcess));
            t.Start(startNum);
            
            return t;
        }
    
        private void WorkerProcess(object startNum)
        {
            
                ProcessMe((int)startNum);
            
        }
    
        private void ProcessMe(int index)
        {
            Random rand = new Random();
    
            semaphore.WaitOne();
    
    
            lvItems.BeginInvoke(myDelegate, index, Color.Red);
    
            Thread.Sleep(rand.Next(500, 5000));
    
            lvItems.BeginInvoke(myDelegate, index, Color.Yellow);
    
            semaphore.Release();
            
        }
        public delegate void  ChangeBack(int index, Color c);
        private ChangeBack myDelegate;
        private void ChangeBackMethod(int index, Color c)
        {
    
            lvItems.BeginUpdate();
            ((ListViewItem)(lvItems.Items[index])).BackColor = c;
            lvItems.EndUpdate();
        }
    
        public DateTime PauseForMilliSeconds(int MilliSecondsToPauseFor)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MilliSecondsToPauseFor);
            DateTime AfterWards = ThisMoment.Add(duration);
    
            while (AfterWards >= ThisMoment)
            {
                //System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
    
            return DateTime.Now;
        }
        }
    }
