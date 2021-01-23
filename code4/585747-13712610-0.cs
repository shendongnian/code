    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    //get Reactive Extensions and reference them in your project.
    //Reactive Extensions for .NET (Rx .NET) http://msdn.microsoft.com/en-us/data/gg577610
    using System.Reactive.Linq;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Load += Form1_Load;
            }
            async void Form1_Load(object sender, EventArgs e)
            {
                //do independent stuff
                PrepareSomeStuff();
                //notify the DB checking
                label1.Text = "Checking DB";
                //declare an IObservable
                IObservable<bool> startAsync = Observable.Start<bool>(() => CheckConnection()).FirstAsync<bool>();
                //do some other independent stuff
                PrepareSomeOtherStuff();
                //wait for the IObservable to return data
                bool isDbReady = await startAsync;
                label1.Text = "Ready";
            }
            private void PrepareSomeOtherStuff()
            {
                //do some other stuff
                label2.Text += "\r\nDo some other stuff";
            }
            private void PrepareSomeStuff()
            {
                //do stuff
                label2.Text = "Do stuff";
            }
            private bool CheckConnection()
            {
                //do stufff
                System.Threading.Thread.Sleep(5000);
                return true;
            }
        }
    }
 
