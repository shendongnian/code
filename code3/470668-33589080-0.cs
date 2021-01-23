        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        namespace ThreadSample
        {
            public partial class Form1 : Form
            {
                List<string> repSelected = new List<string>();
                XMLandRar xXMLandRar = new XMLandRar();
                BackgroundWorker CreateRarBW = new BackgroundWorker();
                public Form1()
                {
                    InitializeComponent();
                    repSelected = new List<string> { "asdf", "asdfsd", "h;ljj" };
                    CreateRarBW.DoWork += new DoWorkEventHandler(CreateRarBW_DoWork);
                }
                private void Rarbtn_Click(object sender, EventArgs e)
                {
                    //GetReps();
                    //Run worker
                    if (!CreateRarBW.IsBusy)
                    {
                        // This should be done once, maybe in the contructor. Bind to new event.
                        xXMLandRar.ReportProgress += new EventHandler<XMLandRar.ProgressArgs>(xXMLandRar_ReportProgress);
                        CreateRarBW.RunWorkerAsync();
                    }
                }
                protected void xXMLandRar_ReportProgress(object sender, XMLandRar.ProgressArgs e)
                {
                    // Call the UI backgroundworker
                    CreateRarBW.ReportProgress(e.Percentage, e.Message);
                }
                //private void CreateRarBW_DoWork(object sender, DoWorkEventArgs e)
                //{
                //    var worker = sender as BackgroundWorker;
                //    xXMLandRar.RarFiles(repSelected, worker);
                //}
                private void CreateRarBW_DoWork(object sender, DoWorkEventArgs e)
                {
                    var worker = sender as BackgroundWorker;
                    // Attach events to class
                    xXMLandRar.OnDoWork += delegate(object o)
                    {
                        // ...
                        MessageBox.Show("Hey ... Something is going on over there in the classLib .. " + o);
                    };
                    xXMLandRar.OnUpdate += delegate(object o, OnXmlandRarUpdateEventArgs args)
                    {
                        // ...
                        //foreach (object oo in args)
                        {
                            MessageBox.Show("Hey ... Something is going on over there in the classLib .. Message is " + args.Message + " and Percentage is " + args.Percentage);
                        }
                    };
                    xXMLandRar.OnComplete += delegate(object o, XmlandRarCompletedEventArgs args)
                    {
                        MessageBox.Show("Hey ... Something is going on over there in the classLib .. Canceled is " + args.Canceled + " and Finished is " + args.Finished);
                        // ...
                    };
                    xXMLandRar.RarFiles(repSelected);//, worker);
                }
            }
        }
