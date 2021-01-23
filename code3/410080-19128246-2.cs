    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SingleInstanceNP
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                // start listening for named pipe connections
                var namedPipeString = new NamedPipe<string>(NamedPipe<string>.NameTypes.PipeType1);
                namedPipeString.OnRequest += new NamedPipe<string>.Request(namedPipeString_OnRequest);
                namedPipeString.Start();
            }
    
            void namedPipeString_OnRequest(string t)
            {
                MessageBox.Show(t);
            }
        }
    }
